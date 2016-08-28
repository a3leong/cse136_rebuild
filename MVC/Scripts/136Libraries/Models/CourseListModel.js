﻿function CourseListModel() {

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

    this.Create = function (course, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/InsertCourse",
            data: course,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding course.  Is your service layer running?');
            }
        });
    };

    this.Create = function (course, callback) {
        $.ajax({
            async: asyncIndicator,
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

}
