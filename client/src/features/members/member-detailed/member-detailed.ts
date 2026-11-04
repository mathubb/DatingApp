import { Component, inject, OnInit } from '@angular/core';
import { MemberService } from '../../../core/services/member-service';
import { ActivatedRoute } from '@angular/router';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { Member } from '../../../types/member';

@Component({
    imports: [AsyncPipe],
    selector: 'app-member-detailed',
    styleUrl: './member-detailed.css',
    templateUrl: './member-detailed.html',
})
export class MemberDetailed implements OnInit {
    private memberService = inject(MemberService);
    private route = inject(ActivatedRoute);
    protected member$?: Observable<Member>;

    ngOnInit(): void {
        this.member$ = this.loadMember();
    }
    loadMember() {
        const id = this.route.snapshot.paramMap.get('id');
        if (!id) return;
        return this.memberService.getMember(id);
    }
}
