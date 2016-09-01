function CourseListModel() {



    this.GetCourseList = function (callback) {
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

    this.GetCourseListExcludeId = function (id, callback) {
        // TODO change to this when john's code actually supports this
        /** $.ajax({
             method: "GET",
             url: "http://localhost:9393/Api/Course/GetCourseListExcludeId?id=" + id,
             data: "",
             dataType: "json",
             success: function (courseListData) {
                 callback(courseListData);
             },
             error: function () {
                 alert('Error while loading course list.  Is your service layer running?');
             }
         });  **/

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

    this.CreatePrereq = function (parentid, childid, callback) {
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Course/InsertPrereq?cid=" + parentid + "&pid=" + childid,
            data: "",
            dataType: "json",
            success: function (response) {
                if( response===null) {
                    alert('Error creating prerec, response is null')
                    return;
                }
                callback(response);
            },
            error: function () {
                alert('Error while creating prereq.  Is your service layer running?');
            }
        });
    }

    this.LoadPrereqs = function (id, callback) {
       $.ajax({
            method: "GET",
            url: "http://localhost:9393/Api/Course/GetPrereqs?course_id=" + id,
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
            url: "http://localhost:9393/Api/Course/GetCourseDetails?id=" + id,
            dataType: "json",
            success: function (courseData) {
                if (courseData === null) {
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

    this.DeletePrereq = function (cid, pid, callback) {
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Course/DeletePrereq?cid=" + cid + "&pid=" + pid,
            data: "",
            dataType: "json",
            success: function (response) {
                if (response === null) {
                    alert('Error creating prerec, response is null')
                    return;
                }
                callback(response);
            },
            error: function () {
                alert('Error while creating prereq.  Is your service layer running?');
            }
        });
    }

}
