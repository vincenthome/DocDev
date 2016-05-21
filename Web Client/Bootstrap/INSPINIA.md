# Bootstrap.INSPINIA

##Setup New Project

 - NuGet Animate.css
 - NuGet FontAwesome
 - NuGet MetisMenu
 - NuGet jquery.slimscroll

```
App_Start -> Update BundleConfg.cs
Content -> Copy patterns folder
		   Copy Site.css, Style.css
Helpers -> Copy HMTLHelperExtensions.cs
Images -> Copy profile_small.jpg
Scripts -> Copy app folder
Views -> Shared -> 	Copy _Footer.cshtml, _Navigation.cshtml, _RightSidebar.cshtml, _TopNavbar.cshtml, _SkinConfig.cshtml
					Update _Layout.cshtml
```



##Layout Element

- `@Html.Partial("_Navigation")`
- `@Html.Partial("_TopNavbar")`
- `@Html.Partial("_Footer")`
 
##Layout Custom Class
- PageClass give you ability to specify custom style for specific view based on action `<div id="wrapper" class="@Html.PageClass()">`
- Page wraper `<div id="page-wrapper" class="gray-bg @ViewBag.SpecialClass">`

##Layout Options

- .fixed-sidebar `<body class="fixed-sidebar">`
- .fixed-nav
- .navbar-fixed-top in _TopNavbar.cshtml `<nav class="navbar navbar-fixed-top">`
-  .footer .fixed

##Skin

- .skin-1 `<body class="skin-1">`
- .skin-2
- .skin-3
- .md-skin
- Default skin doesn't need any class

##Page Level Plugin

At the bottom of page (view)

```
@section Styles {
    @Styles.Render("~/plugins/iCheckStyles")
}
 
@section Scripts {
    @Scripts.Render("~/plugins/iCheck")
 
    <script type="text/javascript">
        $(document).ready(function () {
 
            // Local scripts
 
        });
    </script>
}
```

##Interesting Items

###Form Elements

- Awesome bootstrap checkbox (http://webapplayers.com/inspinia_admin-v2.3/form_advanced.html)
- Select 
	- https://select2.github.io  works
	- http://harvesthq.github.io/chosen
- jQuery Cascading Dropdown https://github.com/dnasir/jquery-cascading-dropdown
- Switch http://abpetkov.github.io/switchery
- Custom Switch Pure CSS ON/OFF http://webapplayers.com/inspinia_admin-v2.3/form_advanced.html
- Date Picker
	- https://github.com/amsul/pickadate.js
	- https://github.com/eternicode/bootstrap-datepicker
	- https://github.com/dangrossman/bootstrap-daterangepicker
- Time Picker 
	- http://amsul.ca/pickadate.js/time
	- https://github.com/weareoutman/clockpicker
- Input Mask
	- Simple http://www.jasny.net/bootstrap/javascript/#inputmask
	- Complete https://github.com/RobinHerbots/jquery.inputmask
- Time Picker http://webapplayers.com/inspinia_admin-v2.3/form_advanced.html
- File Upload http://webapplayers.com/inspinia_admin-v2.3/form_file_upload.html
- Wizard jQuery Steps http://www.jquery-steps.com
- Range Slider
	- https://github.com/IonDen/ion.rangeSlider
	- http://refreshless.com/nouislider
- Knob Dial http://anthonyterrien.com/knob
- Modal / Dialog
	- https://github.com/nakupanda/bootstrap3-dialog
	- http://bootboxjs.com
- Image Gallery https://github.com/dimsemenov/photoswipe
	

###Pages

- Search Result
- 404 Not Found
- 500 Internal Server Error

###More