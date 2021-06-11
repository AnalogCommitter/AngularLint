import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultComponent } from './result/result.component';
import { TipComponent } from './tip/tip.component';

const routes: Routes = [
  { path: 'place-tip', component: TipComponent },
  { path: 'get-result', component: ResultComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
