function StudentViewModel() {

    var StudentModelObj = new StudentModel();
    var self = this;
    var initialBind = true;
    var studentListViewModel = ko.observableArray();

    this.Initialize = function() {

        var viewModel = {
            id: ko.observable("A0000111"),
            ssn: ko.observable("555-55-3333"),
            first: ko.observable("Bruce"),
            last: ko.observable("Wayne"),
            email: ko.observable("bwayne@ucsd.edu"),
            password: ko.observable("password"),
            shoesize: ko.observable("10"),
            weight: ko.observable("160"),
            add: function (data) {
                self.CreateStudent(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divStudent"));
    };

    this.CreateStudent = function(data) {
        var model = {
            StudentId: data.id(),
            SSN: data.ssn(),
            FirstName: data.first(),
            LastName: data.last(),
            Email: data.email(),
            Password: data.password(),
            ShoeSize: data.shoesize(),
            Weight: data.weight()
        }

        StudentModelObj.Create(model, function(result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.Load = function (id) {
        var StudentModelObj = new StudentViewModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        StudentModelObj.Load(id, function (result) {

            var viewModel = {
                StudentId:  ko.observable(result.StudentId),
                SSN:  ko.observable(result.SSN),
                FirstName:  ko.observable(result.FirstName),
                LastName:  ko.observable(result.LastName),
                Email:  ko.observable(result.Email),
                Password:  ko.observable(result.Password),
                ShoeSize:  ko.observable(result.ShoeSize),
                Weight:  ko.observable(result.Weight),
                update: function() {
                    self.UpdateStudent(this);
                }
            }

            ko.applyBindings(viewModel , document.getElementById("divStudentEdit"));
        });
    };

    this.GetAll = function() {

        StudentModelObj.GetAll(function(studentList) {
            studentListViewModel.removeAll();

            for (var i = 0; i < studentList.length; i++) {
                studentListViewModel.push({
                    id: studentList[i].StudentId,
                    first: studentList[i].FirstName,
                    last: studentList[i].LastName,
                    email: studentList[i].Email
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: studentListViewModel }, document.getElementById("divStudentListContent"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.LoadEdit = function (id) {
        StudentModelObj.GetDetail(id, function (result) {
            var student = {
                id: ko.observable(result.StudentId),
                first: ko.observable(result.FirstName),
                last: ko.observable(result.LastName),
                email: ko.observable(result.Email),
                shoesize: ko.observable(result.ShoeSize),
                password: ko.observable(result.Password),
                weight: ko.observable(result.Weight),
                major: ko.observable(result.Major),
                ssn: ko.observable(result.SSN),
                add: function(){ 
                    self.UpdateStudent(this);
                }
            };

            if (initialBind) {
                ko.applyBindings(student, document.getElementById("divStudentEdit"));
            }
        })
    };

    this.UpdateStudent = function (data) {

        var model = {
            StudentId: data.id(),
            SSN: data.ssn(),
            FirstName: data.first(),
            LastName: data.last(),
            Email: data.email(),
            Password: data.password(),
            ShoeSize: data.shoesize(),
            Weight: data.weight(),
            Major: data.major()
        };

        console.log(model.StudentId);
        console.log(model.SSN);
        console.log(model.FirstName);
        console.log(model.LastName);
        console.log(model.Email);
        console.log(model.Password);
        console.log(model.ShoeSize);
        console.log(model.Weight);
        console.log(model.Major);

        StudentModelObj.Update(model, function (result) {
            if (result == "ok") {
                alert("Edit student successful");
                location.reload();
            } else {
                alert("Error occurred");
            }
        });

        //ko.applyBindings(model, document.getElementById("divStudentEdit"));
    };

    this.GetDetail = function (id) {
        StudentModelObj.GetDetail(id, function (result) {

            var student = {
                id: result.StudentId,
                first: result.FirstName,
                last: result.LastName,
                email: result.Email,
                shoesize: result.ShoeSize,
                weight: result.Weight,
                ssn: result.SSN,
                major: result.Major
            };

            if (initialBind) {
                ko.applyBindings({ viewModel: student }, document.getElementById("divStudentContent"));
            }
        });
    };

    this.GetStudentAudit = function (id) {
        console.log(id);
        StudentModelObj.GetDetail(id, function (result) {
            var student = {
                id: result.StudentId,
                first: result.FirstName,
                last: result.LastName,
                email: result.Email,
                shoesize: result.ShoeSize,
                weight: result.Weight,
                ssn: result.SSN,
            };

            if (initialBind) {
                ko.applyBindings({ viewModel: student }, document.getElementById("divStudentAuditStudentInfo"));
            }
        });
        
        StudentModelObj.GetFinishedCourses(id, function (courseList) {
            courseListModel = new Array();
            for (var i = 0; i < courseList.length; i++) {
                courseListModel.push({
                    id: courseList[i].CourseId,
                    title: courseList[i].Title,
                    description: courseList[i].Description
                });
            }  

            if (initialBind) {
                console.log("Bind");
                ko.applyBindings({ viewModel: courseListModel }, document.getElementById("divStudentAuditCoursesPassed"));
            }
        });

        StudentModelObj.GetUnfinishedCourses(id, function (courseList) {
            var courseListModel = new Array();
            for (var i = 0; i < courseList.length; i++) {
                courseListModel.push({
                    id: courseList[i].CourseId,
                    title: courseList[i].Title,
                    description: courseList[i].Description
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: courseListModel }, document.getElementById("divStudentAuditCoursesLeft"));
            }
        });

    }

    ko.bindingHandlers.DeleteStudent = {
        init: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function() {
                var id = viewModel.id;

                StudentModelObj.DeleteStudent(id, function(result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        //studentListViewModel.remove(viewModel);
                        alert("Deletion success!");
                        location.reload();
                    }
                });
            });
        }
    };

    ko.bindingHandlers.DeleteStudentAsync = {
        init: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function() {
                var id = viewModel.id;

                StudentModelObj.DeleteAsync(id, function(result) {
                    alert(result);
                    //studentListViewModel.remove(viewModel);
                });
            });
        }
    };

    

}
