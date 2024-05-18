import { createYmaps } from 'vue-yandex-maps';

export default (app: any) => {
    app.use(
        createYmaps({
            apikey: 'd90f0f55-4228-4ede-9f2e-4d0334dda636',
        })
    )
}
