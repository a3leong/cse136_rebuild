function CourseListViewModel() {
    var self = this;
    var courseListModelObj = new CourseListModel();


    this.HelpCreateCourse = function() {

        var viewModel = {
            id: ko.observable("enter id here"),
            title: ko.observable("enter course title here"),
            level: ko.observable("enter course level here"),
            description: ko.observable("enter description"),
            add: function (data) {
                self.CreateCourse(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divCreateCourses"));
    };

    this.CreateCourse = function (data) {
        var model = {
            CourseId: data.id,
            Title: data.title,
            CourseLevel: data.level,
            Description: data.description
        }

        courseListModelObj.CreateCourse(model, function (result) {
            if (result == "ok") {
                alert("Create course successful");
            } else {
                alert("Error occurred! Make sure the id is unique!");
            }
        });
    };




    this.Load = function () {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        courseListModelObj.GetCourseList(function (courseListData) {

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

    this.LoadByStaff = function () {

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        courseListModelObj.GetCourseList(function (courseListData) {
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

    this.HelpUpdateCourse = function (id) {
        courseListModelObj.GetCourse(id, function (courseData) {
            var viewModel = {
                id: ko.observable(courseData.CourseId),
                title: ko.observable(courseData.Title),
                level: ko.observable(courseData.CourseLevel),
                description: ko.observable(courseData.Description),
                update: function () {
                    self.UpdateCourse(this);
                }
            };

            ko.applyBindings(viewModel, document.getElementById("divEditCourse"));
        })

    };

    this.UpdateCourse = function (data) {
        var model = {
            CourseId: data.id(),
            Title: data.title(),
            Level: data.level(),
            Description: data.description()
        };

        courseListModelObj.UpdateCourse(model, function (result) {
            if (result == "ok") {
                alert("Update course successful");
                location.reload();
            } else {
                alert("Error occurred");
            }
        });
    };

    ko.bindingHandlers.DeleteCourse = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var id = viewModel.id;

                courseListModelObj.DeleteCourse(id, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        alert("Deletion success!")
                        location.reload();
                    }
                });
            });
        }
    };

    this.CreateRequirement = function (parentid, data) {
        childid = data.selected().id;
        console.log(parentid);
        console.log(childid);
        courseListModelObj.CreatePrereq(parentid, childid, function (result) {
            if (result == "ok") {
                alert("Create prereq successful");
                location.reload();
            } else {
                console.log(result);
                alert("Error occurred");
            }
        });
    }

    this.DeletePrereq(cid,pid) {
        courseListModelObj.DeletePrereq(cid, pid, function (result) {
            if (result == "ok") {
                alert("Delete requirement successful");
                location.reload();
            } else {
                console.log(result);
                alert("Error occurred");
            }
        });
    }

    this.LoadPrereqs = function (id) {
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
                    title: courseListData[i].Title,
                    removeprereq: function () {
                        self.RemovePrereq(id, this.id);
                    }
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: courseListViewModel }, document.getElementById("divCoursePrereqs"));
        });

        // Also load courses for adding
        // TODO: I added id because you might want to make a query where you omit the current course id
        courseListModelObj.GetCourseListExcludeId(id, function (courseListData) {
            // courseList - presentation layer model retrieved from /Major/GetMajorList route.
            // majorListViewModel - view model for the html content
            var courseListViewModel = {
                availablecourses: ko.observableArray([]),
                selected: ko.observable(),
                createprereq: function () {
                    self.CreateRequirement(id,this);
                }
            };

            // DTO from the JSON model to the view model. In this case, majorListViewModel doesn't need the "id" attribute
            for (var i = 0; i < courseListData.length; i++) {
                courseListViewModel.availablecourses.push({
                    id: courseListData[i].CourseId,
                    title: courseListData[i].Title,
                    description: courseListData[i].Description
                });
            }

            ko.applyBindings(courseListViewModel, document.getElementById("divCoursePrereqsAdd"));
        });
    };

}
