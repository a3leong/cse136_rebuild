﻿function MajorModel() {
    this.Create = function (major, callback) {
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Major/InsertMajor",
            data: major,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding major.  Is your service layer running?');
            }
        });
    }

    this.Update = function (major, callback) {
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Major/UpdateMajor",
            data: major,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while updating major.  Is your service layer running?');
            }
        });
    }

    this.LoadMajor = function (id, callback) {
        $.ajax({
            method: "GET",
            url: "http://localhost:9393/Api/Major/GetMajor?id="+id,
            dataType: "json",
            success: function (majorData) {
                if (majorData === null) {CreateRequirement
                    alert("Error, no data found");
                    return;
                }
                callback(majorData);
            },
            error: function () {
                alert('Error while loading major.  Is your service layer running?');
            }
        });
    };

    this.LoadMajorList = function (callback) {
        $.ajax({
            method: "GET",
            url: "http://localhost:9393/Api/Major/GetMajorList",
            dataType: "json",
            success: function (courseListData) {
                if (courseListData === null) {
                    alert("Error: Could not load data");
                    return;
                }
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        }); 
    };

    this.LoadMajorRequirementList = function (id, callback) {
        $.ajax({
            method: "GET",
            url: "http://localhost:9393/Api/Major/GetMajorRequirements?id="+id,
            dataType: "json",
            success: function (requirementList) {
                if (requirementList === null) {
                    alert("Error loading course list");
                }
                callback(requirementList);
            },
            error: function () {
                alert('Error while loading requirements list.  Is your service layer running?');
            }
        });
    };

    this.DeleteRequirement = function (majorid, courseid, callback) {
        console.log(majorid);
        console.log(courseid);
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Major/DeleteRequirement?major_id=" + majorid + "&course_id=" + courseid,
            dataType: "json",
            success: function (response) {
                if (response === null) {
                    alert("Error creating major requirement relationship");
                }
                callback(response);
            },
            error: function () {
                alert('Error while creating major requirement.  Is your service layer running?');
            }
        }); 
    };

    this.CreateRequirement = function (majorid, courseid, callback) {
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Major/InsertRequirement?major_id=" + majorid + "&course_id=" + courseid,
            dataType: "json",
            success: function (response) {
                if (response === null) {
                    alert("Error creating major requirement relationship");
                }
                callback(response);
            },
            error: function () {
                alert('Error while creating major requirement.  Is your service layer running?');
            }
        }); 
    };

    this.Delete = function (id, callback) {
        $.ajax({
            method: "POST",
            url: "http://localhost:9393/Api/Major/DeleteMajor?id="+id,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleting major.  Is your service layer running?');
            }
        });
    }

}
