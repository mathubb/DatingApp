import { Component, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RegisterCreds, User } from '../../../types/user';

@Component({
    imports: [FormsModule],
    selector: 'app-register',
    styleUrl: './register.css',
    templateUrl: './register.html',
})
export class Register {
    public membersFromHome = input.required<User[]>();
    cancelRegister = output<boolean>();
    protected creds = {} as RegisterCreds

    register() {
        console.log(this.creds);
    }

    cancel() {
        this.cancelRegister.emit(false)
    }
}
