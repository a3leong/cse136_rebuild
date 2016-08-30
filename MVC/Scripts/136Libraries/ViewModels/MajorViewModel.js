function MajorViewModel() {
    var MajorModelObj = new MajorModel();

    this.UpdateMajor = function (data) {
        var model = {
            Id: data.id(),
            FullName: data.fullname(),
            ShorthandName: data.shorthandname(),
            Description: data.description()
        }

        MajorModelObj.Update(model, function (result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });
    };

    this.LoadMajor = function (id) {
        MajorModelObj.LoadMajor(id, function (majorData) {
            var major = {
                id: majorData.Id,
                fullname: ko.observable(majorData.FullName),
                shorthandname: ko.observable(majorData.ShorthandName),
                description: ko.observable(majorData.Description),
                update: function () {
                    console.log("Update");
                   // self.UpdateMajor(this);
                }
            };
            ko.applyBindings({ viewModel: major }, document.getElementById("divMajorEdit"));
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
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: requirementListViewModel }, document.getElementById("divMajorRequirementListContent"));
        });
    };
}

