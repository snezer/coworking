import axios, { AxiosInstance } from 'axios'
import { ref } from "vue";

interface IParamsUseAxiosAuth {
    baseURL: string,
    getAccessToken: string
}
export function useAxiosAuth(props: { baseURL: string}) {

    const config = ref<Object>({
        baseURL: props.baseURL,
        // baseURL: 'https://192.168.0.22:4500/',
        // timeout: 60 * 1000, // таймаут
        withCredentials: true // включим cross-site Access-Control
    })

    const _axios:AxiosInstance = axios.create(config.value)
    // перехватчик запроса
    _axios.interceptors.request.use(
        function (config) {
            // настроим запрос перед отправкой
            config.withCredentials = true
            config.headers = {
                Authorization: `Bearer sdfsdf`,
                Accept: 'application/json'
            }
            return config
        },
        function (error) {
            // обработаем ошибку запроса
            return Promise.reject(error)
        }
    )

    // перехватчик ответа
    _axios.interceptors.response.use(
        function (response) {
            // обрабатываем ответ с данными
            return response.data
        },
        async function (error) {
            // обрабатываем ответ с ошибкой
            const originalRequest = error.config
            if (error.response.status === 401 && error.config && !error.config._isRetry) {
                originalRequest._isRetry = true
                try {
                    return _axios.request(originalRequest)
                } catch (e) {
                    console.log('НЕ АВТОРИЗОВАН')
                }
            }
            return Promise.reject(error)
        }
    )

    return{
        _axios
    }
}
