import {RestService} from "../baseREST.service.ts";
import axios from '../../config/axios'
import {AxiosHeaders} from "axios";
class ConverterPhotoApiService extends RestService<any> {
    constructor() {
        super('Converter', '', axios);
    }

    async convert (level, data) {
        // @ts-ignore
        return await converterPhotoService.createExtended(
            {
                floorId: level,
                floorLayoutContent: data
            }, `PngSvgComnvertFile`, {
            'Content-Type': 'multipart/form-data'
        } as AxiosHeaders)
    }

    async getPhoto(level) {
        return await converterPhotoService.getById(`converted/file/${level}`)
    }
}

export const converterPhotoService = new ConverterPhotoApiService()