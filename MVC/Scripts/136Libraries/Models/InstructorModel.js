function InstructorModel() {

    this.Load = function (callback) {
        /**      $.ajax({
                  url: "http://localhost:9393/Api/Instructor/GetInstructor",
                  data: "",
                  dataType: "json",
                  success: function (instructorData) {
                      callback(instructorData);
                  },
                  error: function () {
                      alert('Error while loading instructors.  Is your service layer running?');
                  }
              });  We do this for part 5 **/
        var Instructor = [];
        Instructor.push({
           first_name: "Gary",
            last_name: "Gillispie",
            title: "Professor"
        });
        Instructor.push({
            first_name: "Richard",
            last_name: "Ord",
            title: "Maestro"
        });
        callback(Instructor);
    };

    this.UpdateInstructor = function (instructor, callback) {
        $.ajax({
            method: 'POST',
            url: "http://localhost:9393/Api/Instructor/UpdateInstructor",
            data: instructor,
            success: function (message) {
                callback(message);
            },
            error: function () {
                callback('Error while updating instructor info');
            }
        });

    };

    this.CreateInstructor = function (instructor, callback) {
        $.ajax({
            async: asyncIndicator,
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

}
