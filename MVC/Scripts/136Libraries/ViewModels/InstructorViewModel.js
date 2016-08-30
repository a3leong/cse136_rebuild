function InstructorViewModel() {

    var self = this;
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

            // instructorList - presentation layer model retrieved from /instructor/GetInstructorList route.
            // InstructorViewModel - view model for the html content
            //var InstructorViewModel = new Array();
            var InstructorViewModel = ko.observableArray();

            // DTO from the JSON model to the view model. In this case, InstructorViewModel doesn't need the "id" attribute
            for (var i = 0; i < instructorData.length; i++) {
                /*InstructorViewModel[i] = {
                    first_name: instructorData[i].FirstName(),
                    last_name: instructorData[i].LastName(),
                    title: instructorData[i].Title()
                }; */
                InstructorViewModel.push({
                    first_name: instructorData[i].FirstName,
                    last_name: instructorData[i].LastName,
                    title: instructorData[i].Title
                });
            }
            console.log(instructorData);
            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: InstructorViewModel } , document.getElementById("divEditInstructors"));
        });
    };

    this.UpdateInstructor = function (data) {
        var model = {
            first_name: data.FirstName,
            last_name: data.LastName,
            title: data.Title   
        };

        courseModelObj.UpdateInstructor(model,  function (result) {
            if (result == "ok") {
                alert("Update instructor successful");
            } else {
                alert("Error occurred");
            }
        });
    };

    this.HelpCreateInstructor = function () {

        var viewModel = {
            id: ko.observable("enter id here"),
            first_name: ko.observable("enter first name here"),
            last_name: ko.observable("enter last name here"),
            title: ko.observable("enter position here"),
            add: function (data) {
                self.CreateInstructor(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divCreateInstructor"));
    };

    this.CreateInstructor = function (data) {
        var instructorModelObj = new InstructorModel();
        var instructor = {
            InstructorId: data.id,
            FirstName: data.first_name,
            LastName: data.last_name,
            Title: data.title
        }

        instructorModelObj.CreateInstructor(instructor, function (result) {
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
