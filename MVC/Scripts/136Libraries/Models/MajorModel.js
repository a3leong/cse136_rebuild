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
        console.log("Loadmajor");
        console.log(Major.Id);
        callback(Major);
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
            Id: 1,
            FullName: "Computer Science",
            ShorthandName: "CS1",
            Description: "Learn how to hello world."
        });
        MajorList.push({
            Id: 2,
            FullName: "Computer Science2",
            ShorthandName: "CS2",
            Description: "Learn how search Stack Overflow."
        });
        callback(MajorList);
    };



    // Requirementlist functions

    this.LoadMajorRequirementList = function (id, callback) {
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
        /**           courseid: requirementListData[i].CourseId,
                    coursetitle: requirementListData[i].Title,
                    courselevel: requirementListData.CourseLevel,
                    coursedescription: requirementListData[i].Description, **/
        var RequirementList = [];
        RequirementList.push({
            CourseId: 1,
            Title: "CS3",
            CourseLevel: "2",
            Description: "Learn C pointers and build a reduced C Compiler."
        });
        RequirementList.push({
            CourseId: 2,
            Title: "CS136",
            CourseLevel: "2",
            Description: "Learn how to build an enterprise web application."
        });
        callback(RequirementList);
    };
}
