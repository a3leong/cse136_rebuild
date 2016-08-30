function InstructorModel() {

    var instructorViewModel = new InstructorViewModel();


    this.Load = function (callback) {
        $.ajax({
            method: 'GET',
            url: "http://localhost:9393/Api/Instructor/GetInstructorList",
            data: "",
            dataType: "json",
            success: function (instructorData) {
                if (instructorData == null) {
                    alert('Error while loading instructors. Did something go wrong?');
                    return;
                } else {
                    //alert('Call back is here! Data obtained!');
                    callback(instructorData);
                }
            },
            error: function () {
                alert('Error while loading instructors.  Is your service layer running?');
            }
        });
    };


    this.GetInstructor = function (id, callback) {
        console.log(id);
        $.ajax({
            method: "GET",
            url: "http://localhost:9393/Api/Instructor/GetInstructor?id=" + id,
            dataType: "json",
            success: function (instructorData) {
                if (instructorData === null) {
                    alert("Error, no data found");
                    return;
                }
                callback(instructorData);
            },
            error: function () {
                alert('Error while loading instructor list.  Is your service layer running?');
            }
        });
    };

    this.UpdateInstructor = function (instructor, callback) {
        $.ajax({
            method: 'POST',
            url: "http://localhost:9393/Api/Instructor/UpdateInstructor",
            data: instructor,
            success: function (message) {
                if (message == "ok") {
                    callback(message);
                }
                else {
                    alert("Error while updating instructor info");
                    return;
                }
            },
            error: function () {
                callback('Error while updating instructor info');
            }
        });

        };

        this.CreateInstructor = function (instructor, callback) {
            $.ajax({
                //async: asyncIndicator,
                method: "POST",
                url: "http://localhost:9393/Api/Instructor/InsertInstructor",
                data: instructor,
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while adding instructor.  Is your service layer running?');
                }
            });
        };

        this.DeleteInstructor = function (id, callback) {
            $.ajax({
                //async: asyncIndicator,
                method: "POST",
                url: "http://localhost:9393/Api/Instructor/DeleteInstructor?id=" + id,
                data: '',
                dataType: "json",
                success: function (result) {
                    callback(result);
                },
                error: function () {
                    alert('Error while deleteing instructor.  Is your service layer running?');
                }
            });
        };

    }
