import { Component, OnInit } from '@angular/core';
import { NzFormatEmitEvent } from 'ng-zorro-antd';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'permisos-tree-view',
  templateUrl: './permisos-tree-view.component.html',
  styleUrls: ['./permisos-tree-view.component.css']
})
export class PermisosTreeViewComponent implements OnInit {

  constructor() { }
  // tslint:disable-next-line: member-ordering
  defaultCheckedKeys = ['0-0-0'];
  // tslint:disable-next-line: member-ordering
  defaultSelectedKeys = ['0-0-0'];
  // tslint:disable-next-line: member-ordering
  defaultExpandedKeys = ['0-0', '0-0-0', '0-0-1'];

  nodes = [
    {
      title: '0-0',
      key: '0-0',
      expanded: true,
      children: [
        {
          title: '0-0-0',
          key: '0-0-0',
          children: [
            { title: '0-0-0-0', key: '0-0-0-0', isLeaf: true },
            { title: '0-0-0-1', key: '0-0-0-1', isLeaf: true },
            { title: '0-0-0-2', key: '0-0-0-2', isLeaf: true }
          ]
        },
        {
          title: '0-0-1',
          key: '0-0-1',
          children: [
            { title: '0-0-1-0', key: '0-0-1-0', isLeaf: true },
            { title: '0-0-1-1', key: '0-0-1-1', isLeaf: true },
            { title: '0-0-1-2', key: '0-0-1-2', isLeaf: true }
          ]
        },
        {
          title: '0-0-2',
          key: '0-0-2',
          isLeaf: true
        }
      ]
    },
    {
      title: '0-1',
      key: '0-1',
      children: [
        { title: '0-1-0-0', key: '0-1-0-0', isLeaf: true },
        { title: '0-1-0-1', key: '0-1-0-1', isLeaf: true },
        { title: '0-1-0-2', key: '0-1-0-2', isLeaf: true }
      ]
    },
    {
      title: '0-2',
      key: '0-2',
      isLeaf: true
    }
  ];

  ngOnInit() {
  }

  nzEvent(event: NzFormatEmitEvent): void {
    console.log(event);
  }
}
