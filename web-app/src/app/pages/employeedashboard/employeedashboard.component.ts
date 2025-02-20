import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ApplyLeaveComponent } from '../../components/apply-leave/apply-leave.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-employeedashboard',
  imports: [MatCardModule, MatButtonModule,MatDialogModule],
  templateUrl: './employeedashboard.component.html',
  styleUrl: './employeedashboard.component.scss',
})
export class EmployeedashboardComponent {
  applyLeave() {
    this.openDialog();
  }

  readonly dialog = inject(MatDialog);
  openDialog(): void {
    let ref = this.dialog.open(ApplyLeaveComponent, {
      panelClass: 'm-auto',
      data: {},
    });
    ref.afterClosed().subscribe((result: any) => {});
  }
}
