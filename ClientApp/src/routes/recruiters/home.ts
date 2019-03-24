import { RecruitersService } from '../../services/recruiters';
import { autoinject } from "aurelia-framework";

@autoinject
export default class {
    recruiters: any;
    constructor(
        private service: RecruitersService
    ){}
    
    async activate() {
        const recruiters = await this.service.getAll();
        if (recruiters)
        this.recruiters = recruiters;
    }
    delete(id: number){
        this.service.delete(id);
    }
}
