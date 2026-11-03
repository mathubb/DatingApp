import { Component, input } from '@angular/core';
import { Member } from '../../../types/member';
import { RouterLink } from '@angular/router';

@Component({
    imports: [RouterLink],
    selector: 'app-member-card',
    styleUrl: './member-card.css',
    templateUrl: './member-card.html',
})
export class MemberCard {
    member = input.required<Member>();
}
