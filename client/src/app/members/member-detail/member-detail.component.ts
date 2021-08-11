import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { GalleryConfig, GalleryItem, ImageItem, GalleryComponent } from 'ng-gallery';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
  template: `
    <gallery [items]="items"></gallery>
  `
})
export class MemberDetailComponent implements OnInit {
  member: Member;
  images: GalleryItem[]

  constructor(private memberService: MembersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMember();
  }
  
  loadMember() {
    this.memberService.getMember(this.route.snapshot.paramMap.get('username')).subscribe(member => {
      this.member = member;
      this.images = [];
      for (const photo of this.member.photos) {
        this.images.push(new ImageItem({ src: photo?.url, thumb: photo?.url }))
      }
    })
  }

}
