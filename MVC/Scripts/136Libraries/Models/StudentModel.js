//// THe reason for asyncIndicator is to make sure Jasmine test cases can run without error
//// Due to async nature of ajax, the Jasmine's compare function would throw an error during
//// a callback. By allowing this optional paramter for StudentModel function, it forces the ajax
//// call to be synchronous when running the Jasmine tests.  However, the viewModel will not pass
//// this parameter so the asynncIndicator would be undefined which is set to "true". Ajax would
//// be async when called by viewModel.
function StudentModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.Create = function (student, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Student/InsertStudent",
            data: student,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding student.  Is your service layer running?');
            }
        });
    };

    this.Delete = function (id, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Student/DeleteStudent?id=" + id,
            data: '',
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleteing student.  Is your service layer running?');
            }
        });
    };

    this.DeleteAsync = function (id, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Student/DeleteStudentAsync?id=" + id,
            data: '',
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleteing student.  Is your service layer running?');
            }
        });
    };

    this.GetAll = function (callback) {
        var url = "http://localhost:9393/Api/Student/GetStudentList?bust=" + new Date();
        $.ajax({
            async: asyncIndicator,
            method: "GET",
            url: url,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while loading student list.  Is your service layer running?');
            }
        });
    };

    this.GetAllByClass = function (id, callback) {
        /**var url = "http://localhost:9393/Api/Student/GetStudentList?id=" + id;
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: url,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while loading student list.  Is your service layer running?');
            }
        }); **/

    };

    this.GetDetail = function (id, callback) {
        var url = "http://localhost:9393/Api/Student/GetStudent?id=" + id + "&bust=" + new Date();
            
        $.ajax({
            async: asyncIndicator,
            method: "GET",
            url: url,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while loading student detail.  Is your service layer running?');
            }
        });
    };

    this.Update = function (student, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Student/UpdateStudent",
            data: student,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding student.  Is your service layer running?');
            }
        });
    };


    this.Load = function (id, callback) {
        $.ajax({
            method: 'GET',
            url: "http://localhost:9393/Api/Student/GetStudentInfo?Id=" + id,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while loading student info.');
                callback("Error while loading student info");
            }
        });
    };

    this.GetUnfinishedCourses = function (id, callback) {
        var unfinished = [];
        unfinished.push({
            CourseId: 3,
            CourseTitle: "Fluency in Information Technology",
            CourseDescription: "get good at using tech"
        });
        unfinished.push({
            CourseId: 4,
            CourseTitle: "Data Structures",
            CourseDescription: "Learn various data structures"
        });

        callback(unfinished);
    };

    this.GetFinishedCourses = function (id, callback) {
        // TODO Make actual ajax call isntead
        var finished = [];
        finished.push({
            CourseId: 9,
            CourseTitle: "Fluency in Information Technology",
            CourseDescription: "get good at using tech"
        });
        finished.push({
            CourseId: 10,
            CourseTitle: "Compilers",
            CourseDescription: "this is a bad class"
        });

        callback(finished);
    };

}
