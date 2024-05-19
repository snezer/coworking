import extractionService from "./extraction.service";
import axios from "../config/axios";
import {AxiosHeaders, AxiosInstance} from "axios";

export class BaseService {
    private readonly  _endpoint: string
    private readonly _versionApi: string
    protected _axios: AxiosInstance

    constructor(endpoint: string, version: string = `v1`, axiosInstance: AxiosInstance = axios) {
        this._endpoint = endpoint
        this._versionApi = version
        this._axios = axiosInstance
    }

    protected get apiEndpoint(): string {
        return `/api/${this._versionApi.length > 0 ? `${this._versionApi}/` : ``}${this._endpoint}`
    }
}

export class RestService<T> extends BaseService {

    private getAccessToken() {
        // eslint-disable-next-line @typescript-eslint/ban-ts-comment
        // @ts-ignore
        if (!import.meta.env.PROD && import.meta.env.MODE === "development") {
            return 'tokenDevelopment'
        } else {
            return
        }
    }

    token = '/////'

    public async getAll(): Promise<Array<T>> {
        const accessToken = this.token

        const response = await this._axios.get(this.apiEndpoint, {
            headers: {
                'Authorization': `token: ${accessToken}`
            }
        })   ;

        return extractionService.extract(response)
    }

    public async getById<T>(modelId: string | number): Promise<T> {
        const accessToken = this.token
        const response = await this._axios.get(`${this.apiEndpoint}/${modelId}`, {
            headers: {
                'Authorization': `token: ${accessToken}`
            }
        });

        return extractionService.extract(response)
    }

    public async create(model: T): Promise<T> {
        const accessToken = this.token
        const response = await this._axios.post(this.apiEndpoint, model,{
        });

        return extractionService.extract(response)
    }

    public async createExtended(model: T, extendedEndpoint: string, headersCustom: AxiosHeaders = {} as AxiosHeaders): Promise<T> {
        const accessToken = this.token
        const response = await this._axios.post(`${this.apiEndpoint}/${extendedEndpoint}`, model,{
            headers: {
                ...headersCustom
            }
        })

        return  extractionService.extract(response)
    }


    public async update(modelId: string | number, model: T): Promise<any> {
        const accessToken = this.token
        const response = await this._axios.patch(`${this.apiEndpoint}/${modelId}`, model,{
            headers: {
                'Authorization': `token: ${accessToken}`
            }
        });

        return extractionService.extract(response)
    }

    public async updateExtended(
        model: T,
        modelId?: string | number
    ): Promise<any> {
        if (modelId) {
            return await this.update(modelId, model);
        }
        const accessToken = this.token

        const response = await this._axios.patch(`${this.apiEndpoint}`, model,{
            headers: {
                'Authorization': `token: ${accessToken}`
            }
        });
        return extractionService.extract(response)
    }

    public async delete(modelId: string | number): Promise<T> {
        const accessToken = this.token
        const response = await this._axios.delete(`${this.apiEndpoint}/${modelId}`,{
            headers: {
                'Authorization': `token: ${accessToken}`
            }
        });
        return extractionService.extract(response)
    }
}

