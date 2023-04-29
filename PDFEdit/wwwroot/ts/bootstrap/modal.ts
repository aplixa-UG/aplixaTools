namespace org.site.modal {
    export function show(id: string) {
        $(id).modal('show'); 
    }

    export function hide(id: string) {
        $(id).modal('hide'); 
    }
}