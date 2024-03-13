namespace org.site.tooltip {
    export function register(parentSelector: string) {
        $(`${parentSelector} [data-bs-toggle="tooltip"]`).tooltip();
    }

    export function hideAll(parentSelector: string) {
        $(`${parentSelector} [data-bs-toggle="tooltip"]`).tooltip("hide")
    }
}