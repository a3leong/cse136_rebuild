function MajorModel() {
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
                alert('Error while adding major.  Is your service layer running?');
            }
        });
    }

    this.LoadMajor = function (id, callback) {
        $.ajax({
            method: "GET",
            url: "http://localhost:9393/Api/Major/GetMajor?id="+id,
            dataType: "json",
            success: function (majorData) {
                if (majorData === null) {
                    alert("Error, no data found");
                    return;
                }
                callback(majorData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });
        /**var Major = {
            Id: 3,
            FullName: "Critical Gender Studies",
            ShorthandName: "CGS",
            Description: "Study genders and write papers on it"
        }
        console.log("Loadmajor");
        console.log(Major.Id);
        callback(Major);**/
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



    // Requirementlist functions

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
                alert('Error while loading course list.  Is your service layer running?');
            }
        });
    };
}
