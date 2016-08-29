function InstructorViewModel() {


    this.Initialize = function () {

        var viewModel = {
            first_name: ko.observable("Bruce"),
            last_name: ko.observable("Wayne"),
            title: ko.observable("Crime Fighter")
            //add: function (data) {
            //    self.CreateInstructor(data);
            //}
        };

        ko.applyBindings(viewModel, document.getElementById("divInstructorEdit"));
    };




    this.Load = function () {
        var InstructorModelObj = new InstructorModel();

        //alert('Yo, this is the load of InstructorViewModel');

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        InstructorModelObj.Load(function (instructorData) {

            // courseList - presentation layer model retrieved from /instructor/GetInstructor route.
            // InstructorViewModel - view model for the html content
            var InstructorViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, InstructorViewModel doesn't need the "id" attribute
            for (var i = 0; i < instructorData.length; i++) {
                InstructorViewModel[i] = {
                    FirstName: instructorData[i].first_name(),
                    LastName: instructorData[i].last_name(),
                    Title: instructorData[i].title()
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: InstructorViewModel } , document.getElementById("divEditInstructors"));
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

    ko.bindingHandlers.DeleteInstructor = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var id = viewModel.id;

                instructorModelObj.DeleteInstructor(id, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        instructorViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

}
