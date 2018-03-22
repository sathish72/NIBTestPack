class FormChangeListener {
    constructor() {
        this.form = null;
        this.hasChanged = ko.observable(false);
    }

    reset() {
        this.form[0].reset();
        this.hasChanged(false);
    }

    initialize(params) {
        this.form = $(params.form);
        this.form.on("change", () => {
            this.hasChanged(true);
        });
        this.formId = this.form.prop("id");
        return this;
    }
}
