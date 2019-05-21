# Material Design for Razor

Material Design for Razor aims to be a full implementation of [Google's Material Design](https://github.com/material-components/material-components-web) for ASP.NET Core Razor Pages.
For now it will be just a wrapper for the infinitely long classes of Material Design, to make the markup more readable:
```HTML
<button button-type="Outlined" icon="add" icon-position="Right">dhsdhsdh</button>
<floating-action-button icon="favorite" />
<floating-action-button icon="favorite" size="Mini" />
<floating-action-button>Test</floating-action-button>
<floating-action-button icon="favorite">Test</floating-action-button>
<floating-action-button icon="favorite" icon-position="Right">Test</floating-action-button>
<floating-action-button />
<br />
<icon-button icon="favorite" />
<icon-button icon="favorite_border" on-icon="favorite" />
<icon-button icon="favorite_border" on-icon="favorite" is-toggled="true" />
<card>
    <primary-content>
        <media aspect-ratio="SixteenToNine" image="https://material-components.github.io/material-components-web-catalog/static/media/photos/3x2/2.jpg"></media>
    </primary-content>
</card>
```
#### Result:

![Image of Material Design controls](https://pbs.twimg.com/media/D7GNt3kXYAIMfzT.jpg:large)