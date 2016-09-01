function MajorViewModel() {
    var MajorModelObj = new MajorModel();
    var self = this;

    this.LoadCreateMajor = function () {
        var viewModel = {
            fullname: ko.observable("New Major"),
            shorthandname: ko.observable("NMJ"),
            description: ko.observable("Description Here"),
            create: function () {
                self.CreateMajor(this);
            }
        };
        ko.applyBindings(viewModel, document.getElementById("divMajorEdit"));
    };

    this.LoadMajor = function (id) {
        MajorModelObj.LoadMajor(id, function (majorData) {
            var viewModel = {
                id: ko.observable(majorData.Id),
                fullname: ko.observable(majorData.FullName),
                shorthandname: ko.observable(majorData.ShorthandName),
                description: ko.observable(majorData.Description),
                update: function () {
                    self.UpdateMajor(this);
                }
            };
            ko.applyBindings(viewModel, document.getElementById("divMajorEdit"));
        });
    };

    this.UpdateMajor = function (data) {
        var model = {
            Id: data.id(),
            FullName: data.fullname(),
            ShorthandName: data.shorthandname(),
            Description: data.description()
        }

        MajorModelObj.Update(model, function (result) {
            if (result == "ok") {
                alert("Update major successful");
                location.reload();
            } else {
                console.log(result);
                alert("Error occurred");
            }
        });
    };

    this.CreateMajor = function (data) {
        var model = {
            FullName: data.fullname(),
            ShorthandName: data.shorthandname(),
            Description: data.description()
        }

        MajorModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create Major successful");
            } else {
                alert("Error occurred");
            }
        });
    };

    this.LoadMajorList = function () {
        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        MajorModelObj.LoadMajorList(function (majorListData) {

            // courseList - presentation layer model retrieved from /Major/GetMajorList route.
            // majorListViewModel - view model for the html content
            var majorListViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, majorListViewModel doesn't need the "id" attribute
            for (var i = 0; i < majorListData.length; i++) {
                majorListViewModel[i] = {
                                            id: majorListData[i].Id,
                                            fullname: majorListData[i].FullName,
                                            shorthandname: majorListData.ShorthandName,
                                            description: majorListData[i].Description,
                                        };
            }
            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: majorListViewModel }, document.getElementById("divMajorList"));
        });
    };

    this.CreateRequirement = function (majorid, data) {
        var courseid = data.selectedcourse().id; // We only need the numbers

        MajorModelObj.CreateRequirement(majorid, courseid, function (result) {
            if (result == "ok") {
                alert("Create requirement successful");
                location.reload();
            } else {
                console.log(result);
                alert("Error occurred");
            }
        });
    };

    this.DeleteRequirement = function (majorid, data) {
        MajorModelObj.DeleteRequirement(majorid, data.courseid, function (result) {
            if (result == "ok") {
                alert("Delete requirement successful");
                location.reload();
            } else {
                console.log(result);
                alert("Error occurred");
            }
        });
    }

    this.LoadMajorRequirements = function (id) {
        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        MajorModelObj.LoadMajorRequirementList(id, function (requirementListData) {

            // courseList - presentation layer model retrieved from /Major/GetMajorList route.
            // majorListViewModel - view model for the html content
            var requirementListViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, majorListViewModel doesn't need the "id" attribute
            for (var i = 0; i < requirementListData.length; i++) {
                requirementListViewModel[i] = {
                    courseid: requirementListData[i].CourseId,
                    coursename: requirementListData[i].Title,
                    courselevel: requirementListData[i].CourseLevel,
                    coursedescription: requirementListData[i].Description,
                    deleterequirement: function () {
                        self.DeleteRequirement(id, this);
                    }
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: requirementListViewModel }, document.getElementById("divMajorRequirementListContent"));
        });

        // Also load courses for adding
        var CourseListModelObj = new CourseListModel();
        CourseListModelObj.GetCourseList(function (courseListData) {
            // courseList - presentation layer model retrieved from /Major/GetMajorList route.
            // majorListViewModel - view model for the html content
            var courseListViewModel = {
                availablecourses: ko.observableArray([]),
                selectedcourse : ko.observable(),
                createrequirement: function () {
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

            ko.applyBindings(courseListViewModel, document.getElementById("divMajorAddRequirement"));
        });
    };

    ko.bindingHandlers.DeleteMajor = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var id = viewModel.id;

                MajorModelObj.Delete(id, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        alert("Deletion success!")
                    }
                });
            });
        }
    };


}

