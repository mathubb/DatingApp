import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
    imports: [FormsModule, RouterLink, RouterLinkActive],
    selector: 'app-nav',
    styleUrl: './nav.css',
    templateUrl: './nav.html',
})
export class Nav {
    protected accountService = inject(AccountService);
    private router = inject(Router)
    protected creds: any = {};

    login() {
        this.accountService.login(this.creds).subscribe({
            next: (result) => {
                this.router.navigateByUrl('/members');
                this.creds = {};
            },
            error: (err) => alert(err),
        });
    }
    
    logout() {
        this.accountService.logout();
        this.router.navigateByUrl('/');
    }
}
