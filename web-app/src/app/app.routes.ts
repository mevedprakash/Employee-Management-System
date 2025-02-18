import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { DepartmentsComponent } from './pages/departments/departments.component';
import { EmployeeComponent } from './pages/employee/employee.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'departments',
    component: DepartmentsComponent,
  },
  {
    path: 'employee',
    component: EmployeeComponent,
  },
];
