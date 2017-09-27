import { Component, OnInit } from '@angular/core';
import { SocialMediaService } from '../services/socialMedia.service';
import { SocialMediaMessage } from '../models/socialMediaMessage';
import { SocialMediaSearch } from '../models/socialMediaSearch';

@Component({
    selector: 'app-social-media',
    templateUrl: 'socialMedia.component.html',
    styleUrls: ['socialMedia.component.css']
})

export class SocialMediaComponent implements OnInit {
    public socialMediaMessage: SocialMediaMessage[] = [];
    public socialMediaSearch: SocialMediaSearch[] = [];
    public tag: string;

    constructor(private service: SocialMediaService) {
    }

    public ngOnInit() {
        this.loadSearches();
    }

    private getMessages(): void {
        if (this.tag && this.tag.trim()) {
            this.service.getTwitterMessages(this.tag.trim())
            .subscribe((res) => {
                this.socialMediaMessage = res;
                if (this.socialMediaMessage.length === 0) {
                    alert('Tweets não encontrados =/');
                } else {
                    this.loadSearches();
                }
            },
            err => alert(err));
        } else {
            alert('Insira uma tag para busca');
        }
    }

    private loadSearches(): void {
        this.service.getAllSearches()
            .subscribe((res) => {
                if (res.length > 0 ) {
                    this.socialMediaSearch = res;
                } else {
                    alert('Buscas Recentes não encontradas');
                }
            },
            err => alert(err));
    }
}
