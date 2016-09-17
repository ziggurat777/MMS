$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

$(document).ready(function () {
    Button.Init();
});

var Button = {
    Init: function () {
        $("#memberModal").on('show.bs.modal', function (event) {
            var button = event.relatedTarget;

            var submitType = null;
            switch ($(button).data('type')) {
                case 'edit':
                    submitType = $("<button type=\"button\" onclick=\"Button.Edit()\" class=\"btn btn-warning submit\">Edit</button>")
                    break;
                case 'delete':
                    submitType = $("<button type=\"button\" onclick=\"Button.Delete()\" class=\"btn btn-danger submit\">Delete</button>")
                    break
                case 'add':
                    submitType = $("<button type=\"button\" onclick=\"Button.Add()\" class=\"btn btn-primary submit\">Add</button>")
                    break;
                default:
                    return;
            }

            var o = $(button).parents('tr');
            var id = $(o).children('.id').text();
            var name = $(o).children('.name').text();
            var email = $(o).children('.email').text();
            var phoneNumber = $(o).children('.phoneNumber').text();

            var modal = $(this);
            modal.find('.modal-title').text($(button).text());
            modal.find("input[name='memberId']").val(id);
            modal.find("input[name='name']").val(name);
            modal.find("input[name='email']").val(email);
            modal.find("input[name='phoneNumber']").val(phoneNumber);

            modal.find('.modal-footer').children('.submit').remove();
            modal.find('.modal-footer').find('.btn-close').before(submitType);

        }).modal({
            backdrop: 'static',
            keyboard: false,
            show: false
        });
    },
    Add: function () {
        $.ajax({
            type: "POST",
            url: Global.Host + Global.API.Create,
            data: data,
            success: success,
            dataType: dataType
        });


        console.log('add');
    },
    Edit: function () {
        console.log('edit');
    },
    Delete: function () {
        var callback = function () {
            window.location.href = "/Home";
        }

        this.SendAjaxRequest("Delete", callback);
    },
    SendAjaxRequest: function (type, callback) {
        var formData = $('#memberInfo').serializeObject();
        var request = {};

        switch (type) {
            case "Add":
                break;
            case "Edit":
                break;
            case "Delete":
                request.type = "GET";
                request.url = Global.Host + Global.API.Delete;
                request.data = { memberid: formData.memberId };
                break;
            case "Search":
                break;
            default:
                return;
        }

        $.ajax({
            type: request.type,
            url: request.url,
            data: request.data,
            dataType: 'jsonp',
            success: callback
        });
    }
}

