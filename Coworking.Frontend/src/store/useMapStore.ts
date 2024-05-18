import {defineStore} from "pinia";


export const  useMapStore = defineStore('useMapStore', {
    state: () => {
        return{
            points: [
                {
                    coordinates: [83.779947, 53.344742],
                    color: '#ff4433',
                    title: 'color <strong>bondi beach water<strong>',
                    draggable: false
                },
                {
                    coordinates: [83.787439, 53.346925],
                    color: '#ff4433',
                    title: 'color <strong>bondi beach water<strong>',
                    draggable: false
                }
            ],
            activePoint: undefined
        }
    },
    actions: {
        setActivePoint(point: any){
            this.activePoint = point
        },
        resetActivePoint(){
            this.activePoint = undefined
        }

    },
    getters: {

    }
})