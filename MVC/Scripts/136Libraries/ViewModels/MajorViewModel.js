function MajorViewModel() {
    var MajorModelObj = new MajorModel();
    var self = this;

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

        alert(model.FullName);

        MajorModelObj.Update(model, function (result) {
            if (result == "ok") {
                alert("Update student successful");
                location.reload();
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

