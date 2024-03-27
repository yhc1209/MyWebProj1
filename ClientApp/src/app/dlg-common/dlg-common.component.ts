import { Component, Inject } from '@angular/core';
// import {
//   MAT_DIALOG_DATA,
//   MatDialogRef,
//   MatDialogTitle,
//   MatDialogContent,
//   MatDialogActions,
//   MatDialogClose,
// } from '@angular/material/dialog';

export interface DlgData {
  Title : string;
  Message : string;
  Response : string;
}

@Component({
  selector: 'app-dlg-common',
  templateUrl: './dlg-common.component.html',
  styleUrls: ['./dlg-common.component.css'],
  // standalone: true,
  // imports: [
  //   MatDialogTitle,
  //   MatDialogContent,
  //   MatDialogActions,
  //   MatDialogClose,
  // ]
})
export class DlgCommonComponent {
  // constructor(
  //   public dialogRef: MatDialogRef<DlgCommonComponent>,
  //   @Inject(MAT_DIALOG_DATA) public data: DlgData,
  // ) {}

  // onNoClick(): void {
  //   this.dialogRef.close();
  // }
}
