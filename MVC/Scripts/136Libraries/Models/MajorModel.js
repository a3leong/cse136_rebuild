function MajorModel() {
    this.Update = function (major, callback) {
  /**      $.ajax({
            async: asyncIndicator,
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
        }); **/
        return "ok";
    }

    this.LoadMajor = function (id, callback) {
        var Major = {
            Id: 3,
            FullName: "Critical Gender Studies",
            ShorthandName: "CGS",
            Description: "Study genders and write papers on it"
        }
        return Major;
    }

    this.LoadMajorList = function (callback) {
  /**      $.ajax({
            url: "http://localhost:9393/Api/Major/GetMajorList",
            data: "",
            dataType: "json",
            success: function (courseListData) {
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });  We do this for part 5 **/
        var MajorList = [];
        MajorList.push({
            FullName: "Computer Science",
            Description: "Learn how to hello world."
        });
        MajorList.push({
            FullName: "Computer Science2",
            Description: "Learn how search Stack Overflow."
        });
        callback(MajorList);
    };
}
