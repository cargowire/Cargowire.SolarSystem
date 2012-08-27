# Notes from Spec

Deadline: 28th Aug
Technologies: WPF or WP7 inc XAML, C# and design patterns
Functionality:
* List planets in *our* solar system including name
* Details view of individual planets with Picture, Distance from sun, Mass, Diameter
Deliverables:
* Zip of Visual Studio project including all dependencies

# Notes from job Ad/Meeting
* Passionate
* C#/.NET + WPF/Silverlight/PRISM/MVVM
* Native C++/COM development. Windows graphics technologies such as GDI/SWE/DirectX/OpenGL.
* Agile, TDD, Patterns, Gang of Four
* Gadgets, Phones, Touch, UX 
* Polygots

# Ideas before starting
* Show passion by doing more than asked
* Create one for each, reusing the models/classes across them all pin-pointing the benefit of MVVM/patterns including Dependency Injection
* Highlight how MVVM allows very different views to be used (not just windows, web, phone but text, 3D etc with same backend code)
* Will need to look up MVVM, Refresh memory of silverlight/WP7, understand limitations of shared libraries across these disperate platforms

# Assumptions
* Database access is not listed as a requirement so is not prioritised
* Although 2010 is listed as prefered Visual Studio it is not mandated
* .NET Framework version is not limited

# Schedule
* Thursday evening: read about MVVM having not directly used before
* Friday evening: Created WP7 version with separated class libraries
* Saturday morning: Reorganised to better make use of portable library, created initial Windows version
* Sunday afternoon: Created web version including WebGL integration
* Monday: Wrote up notes, added tests

# Implementation Notes
* Ended up prioritising the multiple platforms over a polished design or database access (which wasn't explicitly listed and could be easily swapped in
via the dependency injection).
* There are a few 'remarks' notes on various classes within the source code

## Things I had never done before
* Make a WPF app
* Make the silverlight portion of a WP7 app
* Use WebGL
* Use Ninject (I usually use StructureMap)
* Use MVVM in the Wpf style (I have and do use ViewModels in ASP.NET but more as factory/service generated DTO's from controller)

## Project Layout
* Cargowire - portable resuable C# code suitable for any environment
* Cargowire.Web - reusable C# code for web specific environments
* Cargowire.Phone - reusable C# code for phone specific environments
* Cargowire.Windows - reusable C# code for windows specific environments
* Cargowire.SolarSystem - core model library for this solar system project
* Cargowire.SolarSystem.Web - the .NET4.5 website version of this solar system project
* Cargowire.SolarSystem.Windows - the .NET4.5 windows version of this solar system project
* Cargowire.SolarSystem.Phone - the WP7.1 version of this solar system project

## Portable Class libraries
* Wanted to share as much code as possible, reducing 'copy paste' and therefore saving on maintenance/testing
* Portable class libraries have limitations such as a lack of support for INotifyPropertyChanged except for .NET4.5 http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2393754-support-inotifypropertychanged-and-other-types-i
** This limitation is what pushed me towards .NET4.  At Headscape we have MSDN access to Visual Studio 2012 and .NET4.5 is freely available for download
** Unfortunately you can't make WP7 projects in VS2012 at the moment so that stays in VS2010
* ASP.NET projects are less used within this arrangement, for example ObservableCollection makes a little less sense in a stateless environment
** To avoid needing to reference System.Windows from ASP.NET the view models expose IList (but just use ObservableCollection within themselves)
* Coming from a primarily ASP.NET background MVVM with logic occuring in the View Model (which normally I treat as DTO's with logic occuring in controllers
or factories) was slightly alien to me but by delegating the majority of that to injected dependencies this seems to work.
* By requiring dependencies on ViewModels their creation is difficult.
** Windows: Gets around this by using DataTemplates and a single ViewModel retrieval from container on the main window
** Web: Gets around this by the controllers being hooked into the resolver
** Phone: Cannot get around this easily due to lack of data templates, rather than code around this I just resolve directly in the View code behind (not the greatest)

## Patterns/Best practices
* All: Repository Pattern, Dependency Injection, Reliance on interfaces/contracts rather than concrete, Separation of reusable libraries
* Web: Progressive enhancement, unobtrusive javascript, minimal polution of the global scope
* Phone: MVVM
* Windows: MVVM

## Third party libraries or code
* Text content, images and rough colours of planets come from Wikipedia
* String extensions in Cargowire come from those I previously created for own work
* The main.js pubsub code comes from code I developed and use at Headscape including the 'page:load:*' approach the rest was implementation
for this project
* Ninject used for DI - pulled from Nuget (I normally used Structuremap but Ninject supports WP7)
* PhiloGL was used for the WebGL portion of the web project.  I originally tried to do this raw but in the timeframe and with my experience
was much easier to use the PhiloGL framework
* Used various examples for MVVM (http://www.codeproject.com/Articles/165368/WPF-MVVM-Quick-Start-Tutorial , http://windowsphonegeek.com/articles/Windows-Phone-Mango-Getting-Started-with-MVVM-in-10-Minutes,
http://msdn.microsoft.com/en-us/library/hh563947.aspx), portable libraries (http://visualstudiogallery.msdn.microsoft.com/b0e0b5e9-e138-410b-ad10-00cb3caf4981/),
Ninject (http://dotnet.dzone.com/news/ioc-windows-phone-ninject)

# How Tested
* Bunch of xUnit and Moq powered tests in Cargowire.SolarSystem.Tests mainly surrounding the view models
* Phone built and ran using VS2010 and the WP7 Emulator.  I do have a Lumia 800 but not currently on the WP7 Dev program
* Windows project built and ran from VS2012
* Web project built and ran from VS2012 using the built in web server
** WebGL tested: 
*** Google Chrome
*** Opera (requires hardware acceleration and webgl to be enabled in opera:config - doesn't really work)
*** Firefox 14 (webgl.force-enabled set to true - works but with rougher planet edges to chrome)
*** Internet Explorer (not tested, requires plugin due to Microsofts security concerns around current WebGL)

# Advancements/changes that could be done
* Add a IPlanetRepository implementation that retrieves planets from a data store (perhaps XML for most portability and potential scale of planet content - it's not
as if we go around adding 100 planets to the solar system each day)
* Add an ISolarSystemRepository to allow for other solar systems
* Use a ViewModelFactory/Service layer to avoid using the resolver for this purpose.  This would also allow only the silverlight/wpf factories
to use ObservableCollection and the web one just to use Queryable or List
* Maybe refactor out some of the calculations I ended up doing in views etc into viewmodel or service layer (such as those used by the web view
to get a vague idea of the ratio difference in size/distance between planets - btw I don't think it's great but it kinda works!).  This is sort
of done by behaviours in the windows project.
* Look to use images that are stored as resources rather than copied into each project (although this makes them slightly more annoying to 
swap out in a web environment for example).
* If this was going live the JS would be grouped and minified
* Use of dependency injection could be furthered e.g. so that all commands delegate essentially.  Allowing portable view models with distinct command actions.
* 'Polish' like welcome screens and/or further design
* Did not get to look into/use Prism