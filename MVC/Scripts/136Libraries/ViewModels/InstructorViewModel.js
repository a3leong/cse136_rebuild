﻿function InstructorViewModel() {

    var self = this;
    this.InitializeInstructorEdit = function (id) {
        var instructorModelObj = new InstructorModel();
        instructorModelObj.GetInstructor(id, function (instructorData) {
            var viewModel = {
                id: ko.observable(instructorData.InstructorId),
                first_name: ko.observable(instructorData.FirstName),
                last_name: ko.observable(instructorData.LastName),
                title: ko.observable(instructorData.Title),
                update: function () {
                    self.UpdateInstructor(this);
                }
            };

            ko.applyBindings(viewModel, document.getElementById("divInstructorEdit"));
        })
        
    };

    this.UpdateInstructor = function (data) {
        var model = {
            InstructorId: data.id(),
            FirstName: data.first_name(),
            LastName: data.last_name(),
            Title: data.title()
        };

        var instructorModelObj = new InstructorModel();

        instructorModelObj.UpdateInstructor(model, function (result) {
            if (result == "ok") {
                alert("Update instructor successful");
                location.reload();
            } else {
                alert("Error occurred");
            }
        });
    };


    this.Load = function () {
        var InstructorModelObj = new InstructorModel();

        InstructorModelObj.Load(function (instructorData) {

            var InstructorViewModel = ko.observableArray();

            // DTO from the JSON model to the view model. In this case, InstructorViewModel doesn't need the "id" attribute
            for (var i = 0; i < instructorData.length; i++) {
                InstructorViewModel.push({
                    id: instructorData[i].InstructorId,
                    first_name: instructorData[i].FirstName,
                    last_name: instructorData[i].LastName,
                    title: instructorData[i].Title
                });
            }
            //console.log(instructorData);
            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: InstructorViewModel } , document.getElementById("divEditInstructors"));
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
                var instructorModelObj = new InstructorModel();

                instructorModelObj.DeleteInstructor(id, function (result) {
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
