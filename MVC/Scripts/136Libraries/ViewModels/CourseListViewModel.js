function CourseListViewModel() {
    this.Load = function () {
        var courseListModelObj = new CourseListModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        courseListModelObj.Load(function (courseListData) {

            // courseList - presentation layer model retrieved from /Course/GetCourseList route.
            // courseListViewModel - view model for the html content
            var courseListViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, courseListViewModel doesn't need the "id" attribute
            for (var i = 0; i < courseListData.length; i++) {
                courseListViewModel[i] = {
                    id: courseListData[i].CourseId,
                    title: courseListData[i].Title,
                    description: courseListData[i].Description
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: courseListViewModel }, document.getElementById("divCourseListContent"));
        });
    };

    this.LoadByStaff = function (id) {
            var courseListModelObj = new CourseListModel();

            // Because the Load() is a async call (asynchronous), we'll need to use
            // the callback approach to handle the data after data is loaded.
            courseListModelObj.LoadByStaff(id, function (courseListData) {

                // courseList - presentation layer model retrieved from /Course/GetCourseList route.
                // courseListViewModel - view model for the html content
                var courseListViewModel = new Array();

                // DTO from the JSON model to the view model. In this case, courseListViewModel doesn't need the "id" attribute
                for (var i = 0; i < courseListData.length; i++) {
                    courseListViewModel[i] = {
                        id: courseListData[i].CourseId,
                        title: courseListData[i].Title,
                        description: courseListData[i].Description
                    };
                }

                // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
                ko.applyBindings({ viewModel: courseListViewModel }, document.getElementById("divCourseListStaffContent"));
            });
    };

    this.Create = function (data) {
        var model = {
            Title: data.title(),
            Level: data.level(),
            Description: data.description()
        }

        courseListModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create course successful");
            } else {
                alert("Error occurred");
            }
        });
    }

    this.Create = function (data) {
        var model = {
            Title: data.title(),
            Level: data.level(),
            Description: data.description()
        }

        courseListModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create course successful");
            } else {
                alert("Error occurred");
            }
        });
    }

    this.Update = function (data) {
        var model = {
            Title: data.title(),
            Level: data.level(),
            Description: data.description()
        }

        courseListModelObj.Update(model, function (result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    ko.bindingHandlers.Delete = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var id = viewModel.id;

                courseListModelObj.Delete(id, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        courseListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

    this.LoadPrereqs = function (id) {
        var courseListModelObj = new CourseListModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        courseListModelObj.LoadPrereqs(id, function (courseListData) {

            // courseList - presentation layer model retrieved from /Course/GetCourseList route.
            // courseListViewModel - view model for the html content
            var courseListViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, courseListViewModel doesn't need the "id" attribute
            for (var i = 0; i < courseListData.length; i++) {
                courseListViewModel[i] = {
                    id: courseListData[i].CourseId,
                    title: courseListData[i].Title
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: courseListViewModel }, document.getElementById("divCoursePrereqs"));
        });
    };

}
