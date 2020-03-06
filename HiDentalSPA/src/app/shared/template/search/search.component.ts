import { Component } from '@angular/core';

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html'
})

export class SearchComponent {

    search : any

    files = [
        {
            title: 'Quater Report.exl',
            desc: 'by Finance',
            icon: 'file-excel',
            color: 'ant-avatar-' + 'cyan'
        },
        {
            title: 'Documentaion.docx',
            desc: 'by Developers',
            icon: 'file-word',
            color: 'ant-avatar-' + 'blue'
        },
        {
            title: 'Recipe.txt',
            desc: 'by The Chef',
            icon: 'file-text',
            color: 'ant-avatar-' + 'purple'
        },
        {
            title: 'Project Requirement.pdf',
            desc: 'by Project Manager',
            icon: 'file-pdf',
            color: 'ant-avatar-' + 'red'
        }
    ]

}

