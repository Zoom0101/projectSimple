var app = {};
var EnterKey = 13;
//Tạo model lưu trữ tiêu đề, trạng thái
app.Todo = Backbone.Model.extend({
    default: {
        title: '',
        completed: false
    },
});
//Tạo Collection để lưu trữ nhóm model
app.TodoList = Backbone.Collection.extend({
    model: app.Todo,
    localStorage: new Store("backbone-todo"),
});

//TẠO VIEW

app.TodoView = Backbone.View.extend({
    tagName: 'li',
    template: _.template($('#item-template').html()), //Lưu hàm mẫu với 1 item
    render: function() {
        this.$el.html(this.template(this.model.toJSON()));
        this.input = this.$('.edit');
        return this;
    },
    initialize: function() {
        this.model.on('change', this.render, this); //Thay đổi dom
        this.model.on('destroy', this.remove, this); // xóa khỏi DOM
    },
    events: { //sự kiện dom cụ thể cho một item
        'dblclick span': 'edit',
        'keypress .edit': 'updateOnEnter',
        'blur .edit': 'close',
        'click .destroy': 'destroy'
    },
    edit: function() {
        this.$el.addClass('editing');
        this.input.focus();
    },
    close: function() { //Đóng chỉnh sửa và lưu thay đổi
        var value = this.input.val().trim();
        if (value) {
            this.model.save({
                title: value
            });
        }
        this.$el.removeClass('editing');
    },
    updateOnEnter: function(e) {
        if (e.which == EnterKey) {
            this.close();
        }
    },
    destroy: function() {
        this.model.destroy();
    }
});

//Tao view hien thi todoList
app.AppView = Backbone.View.extend({
    el: '.container', //Liên kết với class trong html
    tagName: 'li',
    template: _.template($('#item-template').html()), //Lưu hàm mẫu với 1 item
    render: function() {
        this.$el.html(this.template(this.model.toJSON()));
        this.input = this.$('.edit');
        return this;
    },
    initialize: function() {
        this.input = this.$('#new-todo');

        app.todoList = new app.TodoList();

        app.todoList.on('add', this.addAll, this);
        app.todoList.on('reset', this.addAll, this);
        app.todoList.fetch(); //Load dữ liệu từ local storage
    },
    events: {
        'keypress #new-todo': 'createTodoOnEnter',
        'click  #btnAdd': 'createTodoOnClick',
    },

    createTodoOnClick: function() {
        if (!this.input.val().trim()) {
            return;
        }
        app.todoList.create(this.newAttributes());
        this.input.val('');
    },
    createTodoOnEnter: function(e) {
        if (e.which !== EnterKey || !this.input.val().trim()) {
            return;
        }
        app.todoList.create(this.newAttributes());
        this.input.val('');
    },
    //Them mot item va noi no vao 'ul'
    addOne: function(todo) {
        var view = new app.TodoView({
            model: todo
        });
        $('#todo-list').append(view.render().el); //render dòng mới thêm trên DOM
    },
    //Them tat ca cac item trong todolist cùng lúc
    addAll: function() {
        this.$('#todo-list').html('');
        app.todoList.each(this.addOne, this);
    },
    newAttributes: function() { //Tao thuoc tinh cho muc moi
        return {
            title: this.input.val().trim(),
            completed: false
        }
    }
});
//Khoi tao todoList
app.appView = new app.AppView();