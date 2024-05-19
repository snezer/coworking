import axiosEditor from "../../config/axiosEditor.ts";
import {RestService} from "../baseREST.service.ts";

class EditorApiService extends RestService<any>{
    constructor() {
        super('babel', 'v1', axiosEditor);
    }
    async getAllHomeElements() {
        return await editorService.getById('room')
    }

    async setHomeElements(homeElement) {
        if (homeElement.id){
            return await  editorService.updateExtended( {
                level: homeElement.floor,
                type: homeElement.type,
                positionStart: {
                    x: homeElement.positionStart.x,
                    y: homeElement.positionStart.y
                },
                size: {
                    width: homeElement.size.width,
                    height: homeElement.size.height
                },
                description: homeElement.description,
                name: homeElement.name
            },
                'room/'+homeElement.id,)
        } else {
            return await  editorService.createExtended( {
                level: homeElement.floor,
                type: homeElement.type,
                positionStart: {
                    x: homeElement.positionStart.x,
                    y: homeElement.positionStart.y
                },
                size: {
                    width: homeElement.size.width,
                    height: homeElement.size.height
                },
                description: homeElement.description,
                name: homeElement.name
            },
                'room')
        }

    }

    async deleteHomeElement(idHomeElement) {
        return editorService.delete('room/'+idHomeElement)
    }

    async getFloors() {
        return await editorService.getById('level/66481bad730f18df6aac9152')
    }

    async addFloors(floor) {
        return editorService.createExtended( {
            title: floor.title,
            value: floor.value,
            coworking: floor.coworking
        },
            'level',)
    }

    async addImageFloor(level,data) {
        return await editorService.createExtended(
            data,'level/background/'+level,
            // @ts-ignore
            {
            'Content-Type': 'multipart/form-data'
        })
    }

    async deleteFloor(idLevel) {
        return await editorService.delete('level/'+idLevel)
    }

    async getAllNode(level){
        return await editorService.getById('entity/'+level)
    }
    async  addNode(data) {
        console.log(data)
        if (data.id){
            return await editorService.updateExtended({
                position: {
                    x: data?.position?.x,
                    y: data?.position?.y
                },
                type: data?.type,
                levelId: data?.floor,
                cost: data?.cost.toString(),
                rotation: Number(data?.rotation),
                scale: Number(data?.scale),
                description: data?.description
            }, 'entity/'+data?.id,)
        }else {
            return await editorService.createExtended({
                position: {
                    x: data?.positionStart?.x,
                    y: data?.positionStart?.y
                },
                type: data?.type,
                levelId: data?.floor,
                cost: data?.cost,
                rotation: data?.rotation,
                scale: data?.scale
            }, 'entity',)
        }

    }
    async deleteNode(id){
        return await editorService.delete('entity/'+id)
    }

    async createCoworking(coworking) {
        return await editorService.createExtended(coworking, 'coworking')
    }


}

export const editorService = new EditorApiService()