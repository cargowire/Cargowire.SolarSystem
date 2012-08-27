window.cw = window.cw || {};
cw.mouse = cw.mouse || {};

// PubSub
(function () {
    var subs = {};

    this.sub = function (key, callback) {
        var callbacks = subs[key] = subs[key] || [];
        callbacks.push(callback);
    };

    this.pub = function (key, event) {
        event = event || {};
        var callbacks = subs[key];
        if (callbacks) {
            for (var i = callbacks.length - 1; i >= 0; i--) {
                callbacks[i](event);
            }
        };
    };

    this.max = function (array) {
        return Math.max.apply(Math, array);
    };
    this.min = function (array) {
        return Math.min.apply(Math, array);
    };

}).apply(cw);

// Mouse Helpers
(function () {
    var that = this;
    var currentMousePos = { x: 0, y: 0 };

    this.Init = function () {
        jQuery(document).on('mousemove', that.StoreMousePosition);
    },

    this.StoreMousePosition = function (event) {
        that.currentMousePos = {
            x: event.pageX,
            y: event.pageY
        }
    },

    this.GetCurrentPosition = function () {
        return this.currentMousePos;
    }

    this.Dispose = function () {
        jQuery(document).off('mousemove', that.StoreMousePosition);
        currentMousePos = { x:0, y:0 };
    }
    
}).apply(cw.mouse);

jQuery(function () {
    cw.pub('page:load');
    $('[data-loadclass]').each(function (i, e) {
        var loadClass = $(e).attr('data-loadclass');
        if (loadClass)
            cw.pub('page:load:' + loadClass);
    });
});

cw.sub('page:load:mouse', function(){
    cw.mouse.Init();
});