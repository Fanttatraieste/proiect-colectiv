import { Component } from '@angular/core';
import { SpecialisationService } from 'src/app/services/controllers/SpecialisationService';
import { SharedTableComponent } from '../../shared/shared-table/shared-table.component';
import { SPECIALIZATION_ENDPOINT } from 'src/app/utility/constants';

@Component({
  selector: 'app-specialisations',
  templateUrl: './specialisations.component.html',
  styleUrls: ['./specialisations.component.css'],
  imports: [SharedTableComponent],
  standalone: true,
})
export class SpecialisationsComponent {
  public title = SPECIALIZATION_ENDPOINT;

  constructor(public readonly specialisationsService: SpecialisationService) {}
}
