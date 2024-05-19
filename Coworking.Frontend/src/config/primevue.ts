import PrimeVue from 'primevue/config'
import 'primevue/resources/themes/md-light-indigo/theme.css'
import 'primevue/resources/primevue.css'
import  'primeicons/primeicons.css'

import Button from "primevue/button";
import Dialog from "primevue/dialog";
import Chip from "primevue/chip";
import ContextMenu from "primevue/contextmenu";
import ConfirmPopup from "primevue/confirmpopup";
import ConfirmDialog from "primevue/confirmdialog";
import Listbox from "primevue/listbox";
import Tag from "primevue/tag";
import TabView from "primevue/tabview";
import TabPanel from "primevue/tabpanel";
import InputText from "primevue/inputtext";
import InputNumber from "primevue/inputnumber";
import Textarea from "primevue/textarea";
import CascadeSelect from 'primevue/cascadeselect';
import Divider from "primevue/divider";
import Splitter from "primevue/splitter";
import Sidebar from "primevue/sidebar";
import SplitterPanel from "primevue/splitterpanel";
import SpeedDial from "primevue/speeddial";
import Panel from "primevue/panel";
import Password from "primevue/password";
import Menu from "primevue/menu";
import Inplace from "primevue/inplace";
import ScrollPanel from "primevue/scrollpanel";
import Toolbar from "primevue/toolbar";
import OverlayPanel from "primevue/overlaypanel";
import BlockUI from "primevue/blockui";
import ProgressSpinner from "primevue/progressspinner";
import Accordion from "primevue/accordion";
import AccordionTab from "primevue/accordiontab";
import ProgressBar from "primevue/progressbar";
import Menubar from "primevue/menubar";
import AutoComplete from "primevue/autocomplete";
import FileUpload from "primevue/fileupload";
import Galleria from "primevue/galleria";

import ConfirmationService from 'primevue/confirmationservice';
import ToastService from 'primevue/toastservice'
import Toast from "primevue/toast";
import MultiSelect from "primevue/multiselect";
import TreeTable from "primevue/treetable";
import PickList from "primevue/picklist";
import DataTable from "primevue/datatable";
import Dropdown from "primevue/dropdown";
import Column from "primevue/column";
import Tooltip from 'primevue/tooltip';
import ToggleButton from "primevue/togglebutton";
import Checkbox from 'primevue/checkbox'
import InputMask from "primevue/inputmask";
import Calendar from "primevue/calendar";
import TreeSelect from "primevue/treeselect";
import Card from "primevue/card";
import TriStateCheckbox from "primevue/tristatecheckbox";
import Badge from "primevue/badge";
import Skeleton from "primevue/skeleton";
import SelectButton from "primevue/selectbutton";
import Carousel from "primevue/carousel";
import FloatLabel from "primevue/floatlabel";

import Rating from "primevue/rating";

export default  (app: any) =>{
    app.use(PrimeVue, {
        locale: {
            aria: {
                trueLabel: 'True',
                falseLabel: 'False',
                nullLabel: 'Not Selected',
                star: '1 star',
                stars: '{star} stars',
                selectAll: 'All items selected',
                unselectAll: 'All items unselected',
                close: 'Close',
                previous: 'Previous',
                next: 'Next',
                navigation: 'Navigation',
                scrollTop: 'Scroll Top',
                moveTop: 'Move Top',
                moveUp: 'Move Up',
                moveDown: 'Move Down',
                moveBottom: 'Move Bottom',
                moveToTarget: 'Move to Target',
                moveToSource: 'Move to Source',
                moveAllToTarget: 'Move All to Target',
                moveAllToSource: 'Move All to Source',
                pageLabel: '{page}',
                firstPageLabel: 'First Page',
                lastPageLabel: 'Last Page',
                nextPageLabel: 'Next Page',
                prevPageLabel: 'Previous Page',
                rowsPerPageLabel: 'Rows per page',
                previousPageLabel: 'Previous Page',
                jumpToPageDropdownLabel: 'Jump to Page Dropdown',
                jumpToPageInputLabel: 'Jump to Page Input',
                selectRow: 'Row Selected',
                unselectRow: 'Row Unselected',
                expandRow: 'Row Expanded',
                collapseRow: 'Row Collapsed',
                showFilterMenu: 'Show Filter Menu',
                hideFilterMenu: 'Hide Filter Menu',
                filterOperator: 'Filter Operator',
                filterConstraint: 'Filter Constraint',
                editRow: 'Row Edit',
                saveEdit: 'Save Edit',
                cancelEdit: 'Cancel Edit',
                listView: 'List View',
                gridView: 'Grid View',
                slide: 'Slide',
                slideNumber: '{slideNumber}',
                zoomImage: 'Zoom Image',
                zoomIn: 'Zoom In',
                zoomOut: 'Zoom Out',
                rotateRight: 'Rotate Right',
                rotateLeft: 'Rotate Left'
            },
            startsWith: 'Начинается с',
            contains: 'Содержит',
            notContains: 'Не содержит',
            endsWith: 'Заканчивается на',
            equals: 'Равно',
            notEquals: 'Не равно',
            noFilter: 'Без фильтра',
            lt: 'Less than',
            lte: 'Less than or equal to',
            gt: 'Greater than',
            gte: 'Greater than or equal to',
            dateIs: 'Date is',
            dateIsNot: 'Date is not',
            dateBefore: 'Date is before',
            dateAfter: 'Date is after',
            clear: 'Очистить',
            apply: 'Принять',
            matchAll: 'Match All',
            matchAny: 'Match Any',
            addRule: 'Add Rule',
            removeRule: 'Remove Rule',
            accept: 'Да',
            reject: 'Нет',
            choose: 'Выбрать',
            upload: 'Загрузить',
            cancel: 'Отменить',
            dayNames: ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"],
            dayNamesShort: ["Вос", "Пон", "Вто", "Срд", "Чет", "Птн", "Суб"],
            dayNamesMin: ["Вс","Пн","Вт","Ср","Чт","Пт","Сб"],
            monthNames: ["Январь","Февраль","Март","Апрель","Май","Июнь","Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь"],
            monthNamesShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июн","Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"],
            today: 'Сегодня',
            weekHeader: 'Wk',
            firstDayOfWeek: 1,
            dateFormat: 'mm/dd/yy',
            weak: 'Weak',
            medium: 'Medium',
            strong: 'Strong',
            passwordPrompt: 'Введите пароль',
            emptyFilterMessage: 'Результаты не найдены',
            emptyMessage: 'Нет доступных вариантов'
        }
    })
    app.use(ConfirmationService)
    app.use(ToastService)
    app.directive('tooltip', Tooltip)
    app.component('Button', Button)
    app.component('Dialog' ,Dialog)
    app.component('Chip', Chip)
    app.component('Listbox', Listbox)
    app.component('Tag', Tag)
    app.component('InputText', InputText)
    app.component('InputNumber', InputNumber)
    app.component('Textarea', Textarea)
    app.component('CascadeSelect', CascadeSelect)
    app.component('Divider', Divider)
    app.component('Splitter', Splitter)
    app.component('SplitterPanel', SplitterPanel)
    app.component('SpeedDial', SpeedDial)
    app.component('Sidebar', Sidebar)
    app.component('Panel', Panel)
    app.component('Menu', Menu)
    app.component('Inplace', Inplace)
    app.component('ContextMenu', ContextMenu)
    app.component('ConfirmPopup', ConfirmPopup)
    app.component('ConfirmDialog', ConfirmDialog)
    app.component('Toast', Toast)
    app.component('TabView', TabView)
    app.component('TabPanel', TabPanel)
    app.component('Password', Password)
    app.component('ScrollPanel', ScrollPanel)
    app.component('Toolbar', Toolbar)
    app.component('OverlayPanel', OverlayPanel)
    app.component('MultiSelect', MultiSelect)
    app.component('TreeTable', TreeTable)
    app.component('PickList', PickList)
    app.component('DataTable', DataTable)
    app.component('Dropdown', Dropdown)
    app.component('Column', Column)
    app.component('BlockUI', BlockUI)
    app.component('ProgressSpinner', ProgressSpinner)
    app.component('ProgressBar', ProgressBar)
    app.component('Accordion', Accordion)
    app.component('AccordionTab', AccordionTab)
    app.component('ToggleButton', ToggleButton)
    app.component('Checkbox', Checkbox)
    app.component('InputMask', InputMask)
    app.component('Calendar', Calendar)
    app.component('TreeSelect', TreeSelect)
    app.component('Menubar', Menubar)
    app.component('AutoComplete', AutoComplete)
    app.component('Card', Card)
    app.component('TriStateCheckbox', TriStateCheckbox)
    app.component('Badge', Badge)
    app.component('Skeleton', Skeleton)
    app.component('SelectButton', SelectButton)
    app.component('Carousel', Carousel)
    app.component('FileUpload', FileUpload)
    app.component('FloatLabel', FloatLabel)
    app.component('Galleria', Galleria)
    app.component('Rating', Rating)
}
