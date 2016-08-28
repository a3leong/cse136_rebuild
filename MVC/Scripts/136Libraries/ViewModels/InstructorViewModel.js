function InstructorViewModel() {
    this.Load = function () {
        var InstructorModelObj = new InstructorModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        InstructorModelObj.Load(function (InstructorData) {

            // courseList - presentation layer model retrieved from /instructor/GetInstructor route.
            // InstructorViewModel - view model for the html content
            var InstructorViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, InstructorViewModel doesn't need the "id" attribute
            for (var i = 0; i < InstructorData.length; i++) {
                InstructorViewModel[i] = {
                    first_name: InstructorData[i].first_name,
                    last_name: InstructorData[i].last_name,
                    title: InstructorData[i].title
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: InstructorViewModel }, document.getElementById("divEditInstructors"));
        });
    };

    this.UpdateInstructor = function (data) {
        var model = {
            FirstName: data.first_name(),
            LastName: data.last_name(),
            Title: data.title()   
        };

        courseModelObj.UpdateInstructor(model,  function (result) {
            if (result == "ok") {
                alert("Update instructor successful");
            } else {
                alert("Error occurred");
            }
        });
    };

    this.CreateInstructor = function (data) {
        var model = {
            FirstName: data.first_name(),
            LastName: data.last_name(),
            Title: data.title()
        }

        instructorModelObj.CreateInstructor(model, function (result) {
            if (result == "ok") {
                alert("Create instructor successful");
            } else {
                alert("Error occurred");
            }
        });

    };

}
