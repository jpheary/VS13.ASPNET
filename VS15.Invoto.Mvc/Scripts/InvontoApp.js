var invontoApp = angular.module('InvontoApp', []);

invontoApp.controller('InvontoController', function ($scope, InvontoService) {
    var controller = this;
    $scope.vwContacts = true;
    $scope.vwContact = false;
    $scope.add = function () {
        controller.Action = "Add";
        controller.ContactID = controller.FirstName = controller.LastName = controller.Email = controller.Phone = controller.Birthdate = controller.Profile = controller.Comments = '';
        controller.Profile = "/images/";
        controller.Groups = [];
        $scope.vwContacts = false;
        $scope.vwContact = true;
    }
    $scope.cancel = function () {
        if(confirm("Are you sure you want to cancel?")) {
            controller.Profile = "";
            for (var i = 0; i < controller.GroupList.length; i++) {
                controller.GroupList[i].Selected = false;
            }
            $scope.vwContacts = true;
            $scope.vwContact = false;
        }
    }
    $scope.changeGroup = function (group) {
        if (group.Selected) {
            controller.Groups.push(group);
        }
        else {
            var index = controller.Groups.indexOf(group);
            controller.Groups.splice(index, 1);
        }
    };

    InvontoService.viewContacts().success(function (contacts) {
        controller.contacts = contacts;
    }).error(function (response) { alert(response); })
    InvontoService.listGroups().success(function (groups) {
        //GroupList used for add\edit form
        controller.GroupList = groups;
        for (var i = 0; i < controller.GroupList.length; i++) {
            controller.GroupList[i].Selected = false;
        }
    })

    controller.editContact = function (contact) {
        controller.Action = "Update";
        controller.ContactID = contact.ContactID;
        controller.FirstName = contact.FirstName;
        controller.LastName = contact.LastName;
        controller.Email = contact.Email;
        controller.Phone = contact.Phone;
        controller.Birthdate = contact.Birthdate;
        controller.Profile = contact.Profile;
        controller.Groups = []; //contact.Groups;
        for (var i = 0; i < controller.GroupList.length; i++) {
            controller.GroupList[i].Selected = false;
            for (var j = 0; j < contact.Groups.length; j++) {
                if (controller.GroupList[i].GroupID == contact.Groups[j].GroupID) {
                    controller.Groups.push(controller.GroupList[i]);
                    controller.GroupList[i].Selected = true;
                    break;
                }
            }
        }
        controller.Comments = contact.Comments;
        $scope.vwContacts = false;
        $scope.vwContact = true;
    };
    controller.addeditContact = function () {
        //Persist and add to list (i.e. no refresh)
        var contact;
        if (controller.Action == "Update") {
            contact = controller.getContact(controller.ContactID);
            //contact.ContactID = controller.ContactID;
            contact.Email = controller.Email;
            contact.FirstName = controller.FirstName;
            contact.LastName = controller.LastName;
            contact.Phone = controller.Phone;
            contact.Birthdate = controller.Birthdate;
            contact.Groups = controller.Groups;
            contact.Comments = controller.Comments;
            InvontoService.editContact(contact, function (data) {
                contact.ProfileImage = $scope.fileUrl;
                InvontoService.uploadProfile(contact, function (data) {
                    contact.Profile = data.profile;
                });

                $scope.vwContacts = true;
                $scope.vwContact = false;
                alert("Contact has been updated.");
            });
        }
        else {
            contact = { FirstName: controller.FirstName, LastName: controller.LastName, Email: controller.Email, Phone: controller.Phone, Birthdate: controller.Birthdate, Groups: controller.Groups, Comments: controller.Comments }
            InvontoService.addContact(contact, function (data) {
                contact.ContactID = data.id;
                contact.ProfileImage = $scope.fileUrl;
                InvontoService.uploadProfile(contact, function (data) {
                    contact.Profile = data.profile;
                });

                controller.contacts.push(contact);
                $scope.vwContacts = true;
                $scope.vwContact = false;
                alert("Contact has been added.");
            });
        }
    };
    controller.deleteContact = function (contact) {
        if(confirm("Are you sure you want to delete this contact?")) {
            InvontoService.deleteContact(contact, function (data) {
                controller.contacts.pop(contact);
                alert("Contact deleted.");
            });
        }
    };
    controller.getContact = function (id) {
        var contact = null;
        angular.forEach(controller.contacts, function(con, key) {
            if (con.ContactID == id) contact = con;
        })
        return contact;
    }
});

invontoApp.factory('InvontoService', ['$q', '$http', function ($q, $http) {
    var InvontoService = {};
    InvontoService.viewContacts = function () {
        return $http.get('/home/viewcontacts');
    };
    InvontoService.getContact = function (id) {
        $http({
            url: '/home/readcontact',
            method: 'GET',
            contentType: "application/json; charset=utf-8",
            params: { id: JSON.stringify(id) }
        }).success(function (data, status, headers, config) {
            return data;
        }).error(function (response) {
            alert(response);
        });
    };
    InvontoService.addContact = function (contact, callback) {
        $http({
            url: '/home/createcontact',
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(contact)
        }).success(function (data, status, headers, config) {
            callback(data);
        }).error(function (response) {
            alert(response);
        });
    };
    InvontoService.editContact = function (contact, callback) {
        $http({
            url: "/home/updatecontact",
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(contact)
        }).success(function (data, status, headers, config) {
            callback(data);
        }).error(function (response) {
            alert(response);
        });
    };
    InvontoService.deleteContact = function (contact, callback) {
        $http({
            url: "/home/deletecontact",
            method: 'POST',
            //params: { contactId: JSON.stringify(contactId) }
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify(contact)
        }).success(function (data, status, headers, config) {
            callback(data);
        }).error(function (response) {
            alert(response);
        });
    };
    InvontoService.listGroups = function () {
        return $http.get('/home/listgroups');
    };
    InvontoService.uploadProfile = function (contact, callback) {
        var formdata = new FormData();
        angular.forEach(contact, function (value, key) {
            formdata.append(key, value);
        });

        var deferred = $q.defer();
        $http({
            url: '/home/uploadimage',
            method: "POST",
            data: formdata,
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).success(function (data) {
            deferred.resolve(data);
            callback(data);
        }).error(function (result, status) {
            deferred.reject(status);
        });
        return deferred.promise;
    };
    return InvontoService;
}]);

invontoApp.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function(scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;
            element.bind('change', function(){
                scope.$apply(function(){
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}])

