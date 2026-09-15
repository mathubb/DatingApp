import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RegisterCreds } from '../../../types/user';

@Component({
    imports: [FormsModule],
    selector: 'app-register',
    styleUrl: './register.css',
    templateUrl: './register.html',
})
export class Register {
    protected creds = {} as RegisterCreds

    register() {
        console.log(this.creds);
    }

    cancel() {
        
    }
}
