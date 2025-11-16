import { BaseModel } from '../base/BaseModel';
import { MajorEnum } from '../enums/MajorEnums';
import { SubjectModel } from '../subjects/SubjectModel';

export class SpecialisationModel extends BaseModel {
  name: string;
  noOfYears: number;
  major: MajorEnum;
  subjects: SubjectModel[];

  constructor(
    id: string,
    name: string,
    noOfYears: number,
    major: MajorEnum,
    subjects: SubjectModel[]
  ) {
    super(id);
    this.name = name;
    this.noOfYears = noOfYears;
    this.major = major;
    this.subjects = subjects;
  }
}
