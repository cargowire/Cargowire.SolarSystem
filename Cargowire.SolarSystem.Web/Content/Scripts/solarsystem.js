window.cw = window.cw || {};
cw.mouse = cw.mouse || {};
cw.solar = cw.solar || {};
cw.solar.core = cw.solar.core || {};
cw.solar.ui = cw.solar.ui || {};

// Ability to draw a solar system and fire appropriate events on mouse movement/click
(function () {
    var that = this;
    var pos, gl, program, scene, canvas, camera, currentPlanetId;
    var maxmass, maxdistance, maxdistance;
    var scale;

    this.Init = function (containerSelector) {
        var system = $(containerSelector);
        that.canvas = $('<canvas id="solarsystemvisualisation" width="' + Math.round($(window).width() * 0.95) + '" height="' + Math.round($(window).height() * 0.95) + '""/>').appendTo(system);

        var planetElements = $('.planet');
        planets = [];
        that.maxmass = cw.max(planetElements.map(function () { return $(this).attr('data-mass') }).toArray());
        that.maxdistance = cw.max(planetElements.map(function () { return $(this).attr('data-distancefromsun') }).toArray());
        that.maxdiameter = cw.max(planetElements.map(function () { return $(this).attr('data-diameter') }).toArray());
        that.scale = (that.canvas.width()/4);

        planetElements.each(function (i, e) {
            var currentPlanetElement = $(this);
            var currentPlanet = new PhiloGL.O3D.Sphere({
                pickable: true,
                nlat: 30,
                nlong: 30,
                radius: (currentPlanetElement.attr('data-diameter') / that.maxdiameter) * 10,
                colors: [   currentPlanetElement.attr('data-colourR'),
                            currentPlanetElement.attr('data-colourG'),
                            currentPlanetElement.attr('data-colourB'),
                            (1 / that.maxmass) * currentPlanetElement.attr('data-mass')
                        ]
            });
            currentPlanet.position = {
                x: ((currentPlanetElement.attr('data-distancefromsun') / that.maxdistance) * that.scale) - (that.scale / 2),
                y: 0,
                z: 0
            };
            console.log(currentPlanet.position);
            

            currentPlanet.update();
            currentPlanet.DetailsLocation = $(this).attr('href');
            currentPlanet.Name = $(this).text();
            planets.push(currentPlanet);
        });

        that.InitModels(system, planets);
    },

    this.InitModels = function (system, models) {
        $('ul', system).hide();
        PhiloGL('solarsystemvisualisation', {
            camera: {
                position: {
                    x: 0, y: 0, z: -(Math.sqrt((that.scale * that.scale)-((that.scale / 2) * (that.scale / 2))))
                }
            },
            events: {
                picking: true,
                onClick: function (e, model) {
                    cw.pub("model:click", model);
                },
                onMouseEnter: function (e, model) {
                    cw.pub("model:over", model);
                },
                onMouseLeave: function(e, model) {
                    cw.pub("model:out", model);
                }
            },
            onError: function (e) {
                // Could be for any reason including missing webgl support so hide the system and show it's list again:
                $('ul', system).show();
                $('canvas', system).remove();
                cw.mouse.Dispose();
            },
            onLoad: function (app) {
                that.gl = app.gl;
                that.program = app.program;
                that.scene = app.scene;
                that.canvas = app.canvas;
                that.camera = app.camera;
                
                that.gl.clearColor(0.0, 0.0, 0.0, 1.0);
                that.gl.clearDepth(1.0);
                that.gl.enable(that.gl.DEPTH_TEST);
                that.gl.depthFunc(that.gl.LEQUAL);
                that.gl.viewport(0, 0, +that.canvas.width, +that.canvas.height);
                
                for (model in models)
                {
                    that.scene.add(models[model]);
                }

                that.Draw();
            }
        });
    };

    this.Draw = function ()
    {
        that.gl.clear(that.gl.COLOR_BUFFER_BIT | that.gl.DEPTH_BUFFER_BIT);
        
        var lights = that.scene.config.lights;
        lights.enable = 1;
        lights.ambient = {
            r: 0.2,
            g: 0.2,
            b: 0.2
        };
        lights.directional = {
            color: {
                r: 0.8,
                g: 0.8,
                b: 0.8
            },
            direction: {
                x: -1.0,
                y: -1.0,
                z: -1.0
            }
        };

        that.scene.render();
        PhiloGL.Fx.requestAnimationFrame(that.Draw);
    }
}).apply(cw.solar.core);

// Wire up some app specific UI interactions based on the solar system events
(function () {
    var that = this;

    this.Init = function () {
        cw.solar.core.Init('#solarsystem');

        cw.sub("model:click", function (model) {
            if(model != undefined && model.position != undefined)
                that.ShowDetails(model);
        });

        cw.sub("model:over", function (model) {
            that.ShowToolTip(model, cw.mouse.GetCurrentPosition());
        });
        cw.sub("model:out", function (model) {
            that.HideToolTip();
        });
    },

    this.ShowDetails = function (model) {
        var details = $('#details');
        if (details.length == 0)
            details = $('<div id="details" style="position:absolute;width:'+(($(window).width()*0.8)-10)+'px;height:'+(($(window).height()*0.8)-10)+'px;left:'+($(window).width()*0.1)+'px;top:'+($(window).height()*0.1)+'px;z-index:101"/>').appendTo($('#solarsystem')).click(function(){$(this).hide();});
       
        details.load(model.DetailsLocation, function () { details.show(); });
    },

    this.ShowToolTip = function (model, position) {
        var tooltip = $('#tooltip');
        if(tooltip.length == 0)
            tooltip = $('<p id="tooltip" style="position:absolute;z-index:100"/>').appendTo($('#solarsystem'));
        
        tooltip.text(model.Name);
        tooltip.show();
        tooltip.css('left', position.x);
        tooltip.css('top', position.y);
    },

    this.HideToolTip = function () {
        $('#tooltip').hide();
    }

}).apply(cw.solar.ui);

// Wire up the creation of the solar system when appropriate
cw.sub("page:load:3dsolarsystem", function () {
    cw.solar.ui.Init();
});