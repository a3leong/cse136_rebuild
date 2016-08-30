function CourseListModel() {



    this.Load = function (callback) {
        $.ajax({
            url: "http://localhost:9393/Api/Course/GetCourseList",
            data: "",
            dataType: "json",
            success: function (courseListData) {
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });
    };

    this.LoadByStaff = function (id, callback) {
        // TODO, change to commented out version
        $.ajax({
            url: "http://localhost:9393/Api/Course/GetCourseList",
            data: "",
            dataType: "json",
            success: function (courseListData) {
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });

        /**
         $.ajax({
             url: "http://localhost:9393/Api/Course/GetCourseListByStaff?id=" + id,
             data: "",
             dataType: "json",
             success: function (courseListData) {
                 callback(courseListData);
             },
             error: function () {
                 alert('Error while loading course list.  Is your service layer running?');
             }
         });
         **/
    };

    this.CreateCourse = function (course, callback) {
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Course/InsertCourse",
            data: course,
            dataType: "json",
            success: function (result) {
                alert('Successfully added course!');
                callback(result);
            },
            error: function () {
                alert('Error while adding course.  Is your service layer running?');
            }
        });
    };

    this.UpdateCourse = function (course, callback) {
        $.ajax({
            //async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/UpdateCourse",
            data: course,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while updating course.  Is your service layer running?');
            }
        });
    };

    this.DeleteCourse = function (id, callback) {
        $.ajax({
            //async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/DeleteCourse?id=" + id,
            data: '',
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleteing course.  Is your service layer running?');
            }
        });
    };

    this.LoadPrereqs = function (id, callback) {
        $.ajax({
            url: "http://localhost:9393/Api/Course/GetCourseList",
            data: "",
            dataType: "json",
            success: function (courseListData) {
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });
    }


    this.GetCourse = function (id, callback) {
        console.log(id);
        $.ajax({
            method: "GET",
            url: "http://localhost:9393/Api/Instructor/GetCourse?id=" + id,
            dataType: "json",
            success: function (instructorData) {
                if (instructorData === null) {
                    alert("Error, no data found when attempting to get course");
                    return;
                }
                callback(courseData);
            },
            error: function () {
                alert('Error while loading the course.  Is your service layer running?');
            }
        });
    };

}
