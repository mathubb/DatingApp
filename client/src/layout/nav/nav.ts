import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';

@Component({
    imports: [FormsModule],
    selector: 'app-nav',
    styleUrl: './nav.css',
    templateUrl: './nav.html',
})
export class Nav {
    private account = inject(AccountService)
    protected creds: any = {}

    login() {
        this.account.login(this.creds).subscribe({
            next: result => console.log(result),
            error: err => console.log(err)
        })
    }
}
