var invontoApp = angular.module('InvontoApp', []);

invontoApp.controller('InvontoController', function ($scope, InvontoService) {
    var controller = this;
    controller.Contacts = null;     //Binding list of contacts
    controller.GroupList = null;    //Binding list of groups
    controller.Contact = null;      //Contact for add/edit form

    $scope.vwContacts = true;
    $scope.vwContact = false;
    $scope.add = function () {
        controller.Contact = { Action: "Add", ContactID: 0, FirstName: '', LastName: '', Email: '', Phone: '', Birthdate: '', Profile: "/images/", Comments: '', Groups: [] };
        $scope.vwContacts = false;
        $scope.vwContact = true;
        $scope.fileUrl = "";
        $('#ProfileImage').val(''); //Clear the file input

        //Add a new object to the model and let the template display it
        //TODO: Need to create conditional views to show inputs when id=0
        //var contact = { ContactID: 0, FirstName: '', LastName: '', Email: '', Phone: '', Birthdate: '', Profile: "/images/", Comments: '', Groups: [] };
        //controller.Contacts.push(contact);
    }
    $scope.cancel = function () {
        if(confirm("Are you sure you want to cancel?")) {
            for (var i = 0; i < controller.GroupList.length; i++) {
                controller.GroupList[i].Selected = false;
            }
            $scope.vwContacts = true;
            $scope.vwContact = false;
        }
    }
    $scope.changeGroup = function (group) {
        if (group.Selected) {
            controller.Contact.Groups.push(group);
        }
        else {
            var index = controller.Contact.Groups.indexOf(group);
            controller.Contact.Groups.splice(index, 1);
        }
    };

    //Load contacts and groups
    InvontoService.viewContacts().success(function (contacts) {
        //Load contacts view
        controller.Contacts = contacts;
    }).error(function (response) { alert(response); })
    InvontoService.listGroups().success(function (groups) {
        //Load contact Groups into GroupList- used for add\edit form
        controller.GroupList = groups;
        for (var i = 0; i < controller.GroupList.length; i++) {
            controller.GroupList[i].Selected = false;
        }
    })

    controller.editContact = function (contact) {
        //Setup the edit form
        controller.Contact = { Action: "Update", ContactID: contact.ContactID, FirstName: contact.FirstName, LastName: contact.LastName, Email: contact.Email, Phone: contact.Phone, Birthdate: contact.Birthdate, Profile: contact.Profile, Groups: [], Comments: contact.Comments };
        for (var i = 0; i < controller.GroupList.length; i++) {
            controller.GroupList[i].Selected = false;
            for (var j = 0; j < contact.Groups.length; j++) {
                if (controller.GroupList[i].GroupID == contact.Groups[j].GroupID) {
                    controller.Contact.Groups.push(controller.GroupList[i]);
                    controller.GroupList[i].Selected = true;
                    break;
                }
            }
        }
        $scope.vwContacts = false;
        $scope.vwContact = true;
        $('#ProfileImage').val(''); //Clear the file input
    };
    controller.addeditContact = function () {
        //Persist and add to list (i.e. no refresh)
        var contact = {};
        if (controller.Contact.Action == "Update") {
            contact = controller.getContact(controller.Contact.ContactID);
            //contact.ContactID = controller.Contact.ContactID;
            contact.Email = controller.Contact.Email;
            contact.FirstName = controller.Contact.FirstName;
            contact.LastName = controller.Contact.LastName;
            contact.Phone = controller.Contact.Phone;
            contact.Birthdate = controller.Contact.Birthdate;
            contact.Groups = controller.Contact.Groups;
            contact.Comments = controller.Contact.Comments;
            InvontoService.editContact(contact, function (data) {
                contact.ProfileImage = $scope.fileUrl;
                InvontoService.uploadProfile(contact, function (data) {
                    contact.Profile = data.profile;
                });

                for (var i = 0; i < controller.GroupList.length; i++) {
                    controller.GroupList[i].Selected = false;
                }
                $scope.vwContacts = true;
                $scope.vwContact = false;
                alert("Contact has been updated.");
            });
        }
        else {
            contact = { FirstName: controller.Contact.FirstName, LastName: controller.Contact.LastName, Email: controller.Contact.Email, Phone: controller.Contact.Phone, Birthdate: controller.Contact.Birthdate, Groups: controller.Contact.Groups, Comments: controller.Contact.Comments }
            InvontoService.addContact(contact, function (data) {
                contact.ContactID = data.id;
                contact.ProfileImage = $scope.fileUrl;
                InvontoService.uploadProfile(contact, function (data) {
                    contact.Profile = data.profile;
                });

                controller.Contacts.push(contact);

                for (var i = 0; i < controller.GroupList.length; i++) {
                    controller.GroupList[i].Selected = false;
                }
                $scope.vwContacts = true;
                $scope.vwContact = false;
                alert("Contact has been added.");
            });
        }
    };
    controller.deleteContact = function (contact) {
        //Delete existing contact
        if(confirm("Are you sure you want to delete this contact?")) {
            InvontoService.deleteContact(contact, function (data) {
                controller.Contacts.pop(contact);
                alert("Contact deleted.");
            });
        }
    };
    controller.getContact = function (id) {
        //Return a contact from bound controller.Contacts
        var contact = null;
        angular.forEach(controller.Contacts, function(con, key) {
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
    InvontoService.listGroups = function () {
        return $http.get('/home/listgroups');
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

