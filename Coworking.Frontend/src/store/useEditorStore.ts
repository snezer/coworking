import {defineStore} from "pinia";
import {editorService} from "../services/api/editor.api.service.ts";


export const useEditorStore = defineStore('editorStore', {
    state: () => {
        return {
            floors: [
                {
                    id: 1,
                    title: "1 этаж"
                },
                {
                    id:2,
                    title: "2 этаж",
                    pathImage: '../../assets/scheme/1.png'
                },
            ],
            selectFloorId: 2,
            homeElements: [],
            nodeElements: [],
            selectHomeElement: false,
            selectNode: false,
            selectedNode: {},
            selectedHomeElement: {},
            modeEditor: 'draw', //draw - рисование, select  выбор обьекта для редактирования, searche
            drawTypeElement: 'node',
            searchRoom: [],
        }
    },
    actions: {
        setActiveFloor(floorId: any){
            this.selectFloorId = floorId
        },
        resetActiveFloor(){
            this.selectFloorId = 0
        },
        async set_active_floor(id){
            this.selectFloorId = id
            await this.get_all_nodes()
        },
        add_floor(data){
            let newFloors = editorService.addFloors(data)
           this.floors.push(newFloors)
        },
        async add_image_for_floor( data){
            await editorService.addImageFloor(this.selectFloorId, data)
            await this.get_all_floors()
        },
        async get_all_floors(){
            const allFloors = await editorService.getFloors()
            this.floors = allFloors
            await this.set_active_floor(allFloors[0]?.id)
        },
        async delete_floor(id){
            await editorService.deleteFloor(this.selectFloorId)
            await this.get_all_floors()
        },
        async add_home_element( data){
            data.floor = this.selectFloorId
            if (!data.id){
                data.type = this.drawTypeElement
            }
            //let newElement = {}
            await editorService.setHomeElements(data)
            // switch (state.drawTypeElement) {
            //     case 'room' : newElement = await APIEditorServices.setHomeElements(data)
            //         break;
            // }
            await this.get_all_home_elements()
        },
        async add_node( data) {
            data.floor = this.selectFloorId
            data.type = this.drawTypeElement
            await editorService.addNode(data)
            await this.get_all_nodes()
            //commit('SAVE_NEW_NODE', data)
        },
        // update_home_element({commit}, data){
        //
        // },
        // update_node({commit}, data){
        //
        // },
        select_node( data){
            this.unselect_home_element()
            this.selectedNode = data
        },
        select_home_element(data){
            this.unselect_node()
            this.selectHomeElement = data
            //commit('SAVE_SELECTED_HOME_ELEMENT', data)
        },
        select_home_element_for_searche( data){
            this.searchRoom.push(data)
            if (this.searchRoom.length>2) {
                this.searchRoom = this.searchRoom.shift()
            }
            //commit('SAVE_SEARCHE_HOME_ELEMENT', data)
        },
        async delete_home_element( data){
            const numberHomeElement = this.homeElements.indexOf(data)
            await editorService.deleteHomeElement(data.id)
            await this.get_all_home_elements()
            //dispatch('get_all_home_elements')
            await this.unselect()
            //dispatch('unselect')
            //commit('DELETE_HOME_ELEMENT', numberHomeElement)
        },
        async delete_node(data){
            await editorService.deleteNode(data.id)
            await this.get_all_nodes()
            this.unselect()
        },
        async get_all_home_elements(){
            const homeElement = await editorService.getAllHomeElements()
            this.homeElements = homeElement
            //commit('SAVE_HOME_ELEMENTS', homeElement.data)
        },
        async get_all_nodes(){
            let nodes = await editorService.getAllNode(this.selectFloorId)
            this.nodeElements = nodes
            //commit('SAVE_NODES', nodes.data)
        },
        set_draw_mode_editor(){
            this.modeEditor = "draw"
            //commit('SAVE_EDITOR_MODE', 'draw')
        },
        set_select_mode_editor(){
            this.modeEditor = 'select'
            //commit('SAVE_EDITOR_MODE', 'select')
        },
        set_searche_mode(){
            this.modeEditor = 'search'
            //commit('SAVE_EDITOR_MODE', 'search')
        },
        set_draw_type_element(typeElement){
            this.drawTypeElement = typeElement
            //commit('SAVE_DRAW_TYPE_ELEMENT', typeElement)
        },
        unselect_home_element(){
            this.selectedHomeElement = {}
            this.selectHomeElement = false
            //commit('UNSELECT_HOME_ELEMENT')
        },
        unselect_node(){
            this.selectedNode = {}
            this.selectNode = false
            //commit('UNSELECT_NODE')
        },
        unselect(){
            this.selectedHomeElement = {}
            this.selectHomeElement = false
            this.selectedNode = {}
            this.selectNode = false
            //commit('UNSELECT')
        }
    },
    getters: {
        
    }
})