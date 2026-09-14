import { Component, signal } from '@angular/core';

@Component({
    imports: [],
    selector: 'app-home',
    styleUrl: './home.css',
    templateUrl: './home.html',
})
export class Home {
    protected registerMode = signal(false);

    showRegister() {
        this.registerMode.set(true)
    }
}
